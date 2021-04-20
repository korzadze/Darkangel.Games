using System.IO;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Информация о поселении</para>
    /// </summary>
    public class TownInfo : IBinaryData
    {
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
        public ByteCoordinates2D MapLocation;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public UnknownFieldData Unknown01 = new(1);
        /// <summary>
        /// ??? Позиция
        /// </summary>
        public ByteCoordinates2D Position;
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
        public UnknownFieldData Unknown02 = new(5);
        /// <summary>
        /// ??? Идентификатор спайсового поля
        /// </summary>
        public byte SpiceFieldID;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public UnknownFieldData Unknown03 = new(1);
        /// <summary>
        /// Плотность залегания спайса
        /// </summary>
        public byte SpiceDensity;
        /// <summary>
        /// Неизвестные данные
        /// </summary>
        public UnknownFieldData Unknown04 = new(1);
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
            WaterAmount = (byte)stream.ReadByte(); ;
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
    }
}
