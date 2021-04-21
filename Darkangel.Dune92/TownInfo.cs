using Darkangel.Strings;
using Darkangel.Xml;
using System.IO;
using System.Xml;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Информация о поселении</para>
    /// </summary>
    public class TownInfo : IBinaryData, IXmlWritable
    {
        /// <inheritdoc/>
        public override string ToString()
        {
            var flag = Flags.HasFlag(TownFlags.Hidden) ? ('-') : ('+');
            if ((SubRegion == DuneSubRegions.Atreides) || (SubRegion == DuneSubRegions.Harkonnen))
            {
                return string.Format("{0}{1}({2})", flag, Region, SubRegion);
            }
            else
            {
                return string.Format("{0}{1}-{2}", flag, Region, SubRegion);
            }
        }
        /// <summary>
        /// <para>Регион, которому принадлежит поселение</para>
        /// </summary>
        public DuneRegions Region;
        /// <summary>
        /// <para>Субрегион, которому принадлежит поселение</para>
        /// </summary>
        public DuneSubRegions SubRegion;
        /// <summary>
        /// Пустыня вокруг поселения
        /// </summary>
        public byte DesertAroundSietch;
        /// <summary>
        /// Расположение поселения на карте
        /// </summary>
        public readonly MapCoord MapLocation = new();
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public readonly UnknownFieldData Unknown01 = new(1);
        /// <summary>
        /// ??? Позиция
        /// </summary>
        public readonly MapCoord Position = new();
        /// <summary>
        /// Как выглядит поселение
        /// </summary>
        public byte Apearance;
        /// <summary>
        /// Какая группа создала это поселение
        /// </summary>
        public byte HousedTroopID;
        /// <summary>
        /// Флаги поселения
        /// </summary>
        public TownFlags Flags;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public readonly UnknownFieldData Unknown02 = new(5);
        /// <summary>
        /// ??? Идентификатор спайсового поля
        /// </summary>
        public byte SpiceFieldID;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public readonly UnknownFieldData Unknown03 = new(1);
        /// <summary>
        /// Плотность залегания спайса
        /// </summary>
        public byte SpiceDensity;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public readonly UnknownFieldData Unknown04 = new(1);
        /// <summary>
        /// Количество харвестеров в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte HarvestersAmount;
        /// <summary>
        /// Количество орнитоптеров в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte OrnithoptersAmount;
        /// <summary>
        /// Количество крис-ножей в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte KnivesAmount;
        /// <summary>
        /// Количество лазерных пистолетов в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte LaserGunsAmount;
        /// <summary>
        /// Количество модулей в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte WeirdModulesAmount;
        /// <summary>
        /// Количество атомных бомб в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte AtomicsAmount;
        /// <summary>
        /// Количество саженцев в поселении (включая и те, что выделены группам, находящимся в поселении)
        /// </summary>
        public byte BulbsAmount;
        /// <summary>
        /// Количество воды в поселении
        /// </summary>
        public byte WaterAmount;
        /// <inheritdoc/>
        public void Load(Stream stream)
        {
            Region = (DuneRegions)stream.ReadByte();
            SubRegion = (DuneSubRegions)stream.ReadByte();
            DesertAroundSietch = (byte)stream.ReadByte();
            MapLocation.Load(stream);
            Unknown01.Load(stream);
            Position.Load(stream);
            Apearance = (byte)stream.ReadByte();
            HousedTroopID = (byte)stream.ReadByte();
            Flags = (TownFlags)stream.ReadByte();
            Unknown02.Load(stream);
            SpiceFieldID = (byte)stream.ReadByte();
            Unknown03.Load(stream);
            SpiceDensity = (byte)stream.ReadByte();
            Unknown04.Load(stream);
            HarvestersAmount = (byte)stream.ReadByte();
            OrnithoptersAmount = (byte)stream.ReadByte();
            KnivesAmount = (byte)stream.ReadByte();
            LaserGunsAmount = (byte)stream.ReadByte();
            WeirdModulesAmount = (byte)stream.ReadByte();
            AtomicsAmount = (byte)stream.ReadByte();
            BulbsAmount = (byte)stream.ReadByte();
            WaterAmount = (byte)stream.ReadByte();
        }
        /// <inheritdoc/>
        public void Store(Stream stream)
        {
            stream.WriteByte((byte)Region);
            stream.WriteByte((byte)SubRegion);
            stream.WriteByte(DesertAroundSietch);
            MapLocation.Store(stream);
            Unknown01.Store(stream);
            Position.Store(stream);
            stream.WriteByte(Apearance);
            stream.WriteByte(HousedTroopID);
            stream.WriteByte((byte)Flags);
            Unknown02.Store(stream);
            stream.WriteByte(SpiceFieldID);
            Unknown03.Store(stream);
            stream.WriteByte(SpiceDensity);
            Unknown04.Store(stream);
            stream.WriteByte(HarvestersAmount);
            stream.WriteByte(OrnithoptersAmount);
            stream.WriteByte(KnivesAmount);
            stream.WriteByte(LaserGunsAmount);
            stream.WriteByte(WeirdModulesAmount);
            stream.WriteByte(AtomicsAmount);
            stream.WriteByte(BulbsAmount);
            stream.WriteByte(WaterAmount);
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner)
        {
            var root = owner.AddChild(nameof(TownInfo));
            root.AddAttribute(nameof(Region), Region);
            root.AddAttribute(nameof(SubRegion), SubRegion);
            root.AddAttribute(nameof(DesertAroundSietch),DesertAroundSietch);
            MapLocation.AppendTo(root.AddChild(nameof(MapLocation)));
            Unknown01.AppendTo(root.AddChild(nameof(Unknown01)));
            Position.AppendTo(root.AddChild(nameof(Position)));

            root.AddAttribute(nameof(Apearance), Apearance);
            root.AddAttribute("Bin", string.Format("{0}b", Apearance.IntToStr(2).PadLeft(8, '0')));
            root.AddAttribute("Hex", string.Format("0x{0}", Apearance.IntToStr(16).PadLeft(4, '0')));

            root.AddAttribute(nameof(HousedTroopID), HousedTroopID);
            root.AddAttribute(nameof(Flags), Flags);
            Unknown02.AppendTo(root.AddChild(nameof(Unknown02)));
            root.AddAttribute(nameof(SpiceFieldID), SpiceFieldID);
            Unknown03.AppendTo(root.AddChild(nameof(Unknown03)));
            root.AddAttribute(nameof(SpiceDensity), SpiceDensity);
            Unknown04.AppendTo(root.AddChild(nameof(Unknown04)));
            root.AddAttribute(nameof(HarvestersAmount), HarvestersAmount);
            root.AddAttribute(nameof(OrnithoptersAmount), OrnithoptersAmount);
            root.AddAttribute(nameof(KnivesAmount), KnivesAmount);
            root.AddAttribute(nameof(LaserGunsAmount), LaserGunsAmount);
            root.AddAttribute(nameof(WeirdModulesAmount), WeirdModulesAmount);
            root.AddAttribute(nameof(AtomicsAmount), AtomicsAmount);
            root.AddAttribute(nameof(BulbsAmount), BulbsAmount);
            root.AddAttribute(nameof(WaterAmount), WaterAmount);
        }
    }
}
