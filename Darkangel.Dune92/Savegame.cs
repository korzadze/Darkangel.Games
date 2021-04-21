using Darkangel.IntegerX;
using Darkangel.IO;
using Darkangel.Xml;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Файл сохраненной игры Dune (1992)</para>
    /// </summary>
    public class SaveGame : IXmlWritable
    {
        /// <summary>
        /// <para>Заголовок файла</para>
        /// </summary>
        public readonly SaveHeader Header = new();
        #region Данные о сжатии
        /// <summary>
        /// <para>Максимальное количество последовательно-одинаковых значений, записываемых в поток без счетчика повторов</para>
        /// </summary>
        private const int DefaultMaxUnrepeatedValueCount = 2;
        /// <summary>
        /// <para>Контрольный код</para>
        /// </summary>
        private const byte DefaultControlCode = 0xf7;
        /// <summary>
        /// <para>Размер заголовка</para>
        /// </summary>
        private const int PackingInfoSize = 4;
        /// <summary>
        /// <para>Код блока сжатия?</para>
        /// </summary>
        private byte ControlCode = DefaultControlCode;
        /// <summary>
        /// <para>Максимальное количество последовательно-одинаковых значений, записываемых в поток без счетчика повторов</para>
        /// </summary>
        private byte MaxUnrepeatedValueCount = DefaultMaxUnrepeatedValueCount;
        #endregion
        /// <summary>
        /// <para>Данные</para>
        /// </summary>
        public readonly GameData GameData = new();
        /// <summary>
        /// <para>Загрузить сохраненную игру из файла</para>
        /// </summary>
        /// <param name="fileName">Исходный файл</param>
        public SaveGame(string fileName)
        {
            using FileStream rd = File.OpenRead(fileName);
            Load(rd);
        }
        /// <summary>
        /// <para>Сохранить данные в файл</para>
        /// </summary>
        /// <param name="fileName"></param>
        public void Store(string fileName)
        {
            using FileStream wr = File.OpenWrite(fileName);
            Store(wr);
        }
        private void Load(Stream inStream)
        {
            Header.Load(inStream);
            ControlCode = inStream.ReadUInt8(isLittleEndian: true);
            MaxUnrepeatedValueCount = inStream.ReadUInt8(isLittleEndian: true);
            var dataSize = inStream.ReadUInt16(isLittleEndian: true);
            var size = dataSize - PackingInfoSize;
            if (size > (inStream.Length - inStream.Position))
            {
                throw new FileLoadException();
            }
            using var rawData = Decompress(inStream, size);
            rawData.Position = 0;
            GameData.Load(rawData);
        }
        private void Store(Stream outStream)
        {
            using var rawData = new MemoryStream();
            GameData.Store(rawData);
            rawData.Position = 0;
            using var packedData = Compress(rawData);
            var size = packedData.Length + PackingInfoSize;
            if (size > UInt16.MaxValue)
            {
                throw new OverflowException();
            }

            Header.Store(outStream);
            outStream.Write(ControlCode, isLittleEndian: true);
            outStream.Write(MaxUnrepeatedValueCount, isLittleEndian: true);
            outStream.Write((UInt16)size, isLittleEndian: true);
            packedData.CopyTo(outStream);
        }
        private class ValueCounter
        {
            public byte Value;
            public int Count;
        }
        /// <summary>
        /// <para>Подсчитать повторяющиеся последовательные значения в потоке</para>
        /// </summary>
        /// <param name="inStream">Входные данные</param>
        /// <returns>Значение и количество повторов</returns>
        private static ValueCounter CountValue(Stream inStream)
        {
            var res = new ValueCounter { Value = inStream.ReadUInt8(), Count = 1 };
            while (inStream.Length > inStream.Position)
            {
                if (res.Value != inStream.ReadByte())
                {
                    inStream.Position--;
                    break;
                }
                res.Count++;
            }
            return res;
        }
        /// <summary>
        /// <para>Записать упаковочную последовательность байт в поток</para>
        /// </summary>
        /// <param name="outStream">Целевой поток</param>
        /// <param name="val">Значение</param>
        /// <param name="count">Количество повторов</param>
        private void WriteBytes(Stream outStream, byte val, int count)
        {
            if (count > 0)
            {
                if (val == ControlCode)
                {
                    WritePackSequence(outStream, val, count);
                }
                else if (count <= MaxUnrepeatedValueCount)
                {
                    while (count > 0)
                    {
                        outStream.WriteByte(val);
                        count--;
                    }
                }
                else
                {
                    WritePackSequence(outStream, val, count);
                }
            }
        }
        /// <summary>
        /// <para>Записать кодовую последовательность в поток</para>
        /// </summary>
        /// <param name="outStream">Целевой поток</param>
        /// <param name="val">Значение</param>
        /// <param name="count">Количество повторов</param>
        private void WritePackSequence(Stream outStream, byte val, int count)
        {
            if (count > 0)
            {
                while (count > byte.MaxValue)
                {
                    outStream.WriteByte(ControlCode);
                    outStream.WriteByte(byte.MaxValue);
                    outStream.WriteByte(val);
                    count -= byte.MaxValue;
                }
                outStream.WriteByte(ControlCode);
                outStream.WriteByte((byte)count);
                outStream.WriteByte(val);
            }
        }

        private Stream Decompress(Stream inStream, int size)
        {
            var res = new MemoryStream();
            var buf = inStream.ReadBytes(size);

            for (var i = 0; i < buf.Length; i++)
            {
                if (buf[i] == ControlCode)
                {
                    var count = buf[++i];
                    var val = buf[++i];
                    while (count > 0)
                    {
                        res.WriteByte(val);
                        count--;
                    }
                }
                else
                {
                    res.WriteByte(buf[i]);
                }
            }
            return res;
        }
        private Stream Compress(Stream inStream)
        {
            var res = new MemoryStream();

            var val = (byte)inStream.ReadByte();
            var count = 1;
            while (inStream.Position < inStream.Length)
            {
                var next = (byte)inStream.ReadByte();
                if (val != next)
                {
                    WriteBytes(res, val, count);
                    val = next;
                    continue;
                }
                count++;
            }
            WriteBytes(res, val, count);

            return res;
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner)
        {
            var root = owner.AddChild(nameof(SaveGame));
            Header.AppendTo(root);
            GameData.AppendTo(root);
        }
        /// <summary>
        /// <para>Предоставить информацию о сохраненной игре в виде XML документа</para>
        /// </summary>
        /// <returns>XML документ с данными об игре</returns>
        public XmlDocument ToXml()
        {
            var doc = new XmlDocument();
            var root = doc.CreateElement("Dune");
            doc.AppendChild(root);
            var decl = doc.CreateXmlDeclaration("1.0", Encoding.UTF8.WebName, "yes");
            doc.InsertBefore(decl, root);
            AppendTo(root);
            return doc;
        }
    }
}
