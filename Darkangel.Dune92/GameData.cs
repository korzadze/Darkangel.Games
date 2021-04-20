using Darkangel.IntegerX;
using Darkangel.Xml;
using System;
using System.IO;
using System.Xml;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Распакованные данные сохраненной игры</para>
    /// </summary>
    public class GameData : IBinaryData, IXmlWritable
    {
        /// <summary>
        /// <para>Неизвестные данные</para>
        /// </summary>
        public readonly UnknownFieldData Unknown01 = new(0x4455);
        /// <summary>
        /// <para>Количество спайса в хранилище Атридесов</para>
        /// </summary>
        public int AtriedesSpiceStock
        {
            get => _AtriedesSpiceStock * 10;
            set => _AtriedesSpiceStock = (UInt16)(value / 10);
        }
        private UInt16 _AtriedesSpiceStock;
        /// <summary>
        /// <para>Неизвестные данные</para>
        /// </summary>
        public readonly UnknownFieldData Unknown02 = new(6);
        /// <summary>
        /// <para>Количество спайса в хранилище Харконненов</para>
        /// </summary>
        public int HarkonnenSpiceStock
        {
            get => _HarkonnenSpiceStock * 10;
            set => _HarkonnenSpiceStock = (UInt16)(value / 10);
        }
        private UInt16 _HarkonnenSpiceStock;
        /// <summary>
        /// <para>Неизвестные данные</para>
        /// </summary>
        public readonly UnknownFieldData Unknown03 = new(86);
        /// <summary>
        /// <para>Информация о поселениях</para>
        /// </summary>
        public readonly TownInfo[] Towns = new TownInfo[Defines.TownsMaxCount];
        /// <summary>
        /// <para>Неизвестные данные</para>
        /// </summary>
        public readonly UnknownFieldData Unknown04 = new(2);
        /// <summary>
        /// <para>Информация о группах</para>
        /// </summary>
        public readonly TroopInfo[] Troops = new TroopInfo[Defines.TroopsMaxCount];
        /// <summary>
        /// <para>Неизвестные данные</para>
        /// </summary>
        public readonly UnknownFieldData Unknown05 = new(441);
        /// <summary>
        /// <para>Телепатическая сила Пола (расстояние, на котором он может связываться с группами)</para>
        /// </summary>
        public byte TelepathicStrength;
        /// <summary>
        /// <para>Неизвестные данные</para>
        /// </summary>
        public readonly UnknownFieldData Unknown06 = new(249);
        /// <inheritdoc/>
        public void Load(Stream inStream)
        {
            Unknown01.Load(inStream);
            _AtriedesSpiceStock = inStream.ReadUInt16(isLittleEndian: true);
            Unknown02.Load(inStream);
            _HarkonnenSpiceStock = inStream.ReadUInt16(isLittleEndian: true);
            Unknown03.Load(inStream);
            for (var i = 0; i < Towns.Length; i++)
            {
                Towns[i] = new();
                Towns[i].Load(inStream);
            }
            Unknown04.Load(inStream);
            for (var i = 0; i < Troops.Length; i++)
            {
                Troops[i] = new();
                Troops[i].Load(inStream);
            }
            Unknown05.Load(inStream);
            TelepathicStrength = (byte)inStream.ReadByte();
            Unknown06.Load(inStream);
        }
        /// <inheritdoc/>
        public void Store(Stream outStream)
        {
            Unknown01.Store(outStream);
            outStream.Write(_AtriedesSpiceStock, isLittleEndian: true);
            Unknown02.Store(outStream);
            outStream.Write(_HarkonnenSpiceStock, isLittleEndian: true);
            Unknown03.Store(outStream);
            foreach (var t in Towns)
            {
                t.Store(outStream);
            }
            Unknown04.Store(outStream);
            foreach (var t in Troops)
            {
                t.Store(outStream);
            }
            Unknown05.Store(outStream);
            outStream.WriteByte(TelepathicStrength);
            Unknown06.Store(outStream);
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner)
        {
            var root = owner.AddChild(nameof(GameData));

            Unknown01.AppendTo(root.AddChild(nameof(Unknown01)));
            root.AddAttribute(nameof(AtriedesSpiceStock), AtriedesSpiceStock);
            Unknown02.AppendTo(root.AddChild(nameof(Unknown02)));
            root.AddAttribute(nameof(HarkonnenSpiceStock), HarkonnenSpiceStock);
            Unknown03.AppendTo(root.AddChild(nameof(Unknown03)));
            var n = root.AddChild(nameof(Towns));
            foreach (var t in Towns)
            {
                t.AppendTo(n);
            }
            Unknown04.AppendTo(root.AddChild(nameof(Unknown04)));
            n = root.AddChild(nameof(Troops));
            foreach (var t in Troops)
            {
                t.AppendTo(n);
            }
            Unknown05.AppendTo(root.AddChild(nameof(Unknown05)));
            root.AddAttribute(nameof(TelepathicStrength), TelepathicStrength);
            Unknown06.AppendTo(root.AddChild(nameof(Unknown06)));
        }
    }
}
