using System.IO;
using System.Xml;
using Darkangel.Strings;
using Darkangel.Xml;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Поле неопределенных данных</para>
    /// </summary>
    public class UnknownFieldData : IBinaryData, IXmlWritable
    {
        /// <summary>
        /// <para>Данные поля</para>
        /// </summary>
        public readonly byte[] Data;
        internal UnknownFieldData(long dataSize)
        {
            Data = new byte[dataSize];
        }
        /// <inheritdoc/>
        public void Load(Stream stream)
        {
            if (stream.Read(Data, 0, Data.Length) != Data.Length)
            {
                throw new EndOfStreamException();
            }
        }
        /// <inheritdoc/>
        public void Store(Stream stream)
        {
            stream.Write(Data, 0, Data.Length);
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner) =>
            owner.AddChild("Data").AddText(Data.AsHexString(" "));
    }
}
