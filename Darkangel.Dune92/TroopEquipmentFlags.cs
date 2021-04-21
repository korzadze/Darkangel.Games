using System;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Оборудование группы</para>
    /// </summary>
    [Flags]
    public enum TroopEquipmentFlags : byte
    {
        /// <summary>
        /// <para>Не назначено</para>
        /// </summary>
        NotAssigned = 1 << 0,
        /// <summary>
        /// <para>Саженцы</para>
        /// </summary>
        Bulb = 1 << 1,
        /// <summary>
        /// <para>Атомное оружие</para>
        /// </summary>
        AtomicWeapon = 1 << 2,
        /// <summary>
        /// <para>Модули</para>
        /// </summary>
        WeirdingModule = 1 << 3,
        /// <summary>
        /// <para>Лазерные пистолеты</para>
        /// </summary>
        LaserGun = 1 << 4,
        /// <summary>
        /// <para>Ножи</para>
        /// </summary>
        Krys = 1 << 5,
        /// <summary>
        /// <para>Топтеры</para>
        /// </summary>
        Ornithopter = 1 << 6,
        /// <summary>
        /// <para>Харвестеры</para>
        /// </summary>
        Harvester = 1 << 7,
    }
}
