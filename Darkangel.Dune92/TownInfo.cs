using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Dune92
{
    public class TownInfo
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
    }
}
