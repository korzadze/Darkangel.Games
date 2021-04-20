using System;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Флаги группы</para>
    /// </summary>
    [Flags]
    public enum TroopFlags : byte
    {
        /// <summary>
        /// <para>???</para>
        /// </summary>
        Unknown01 = 1 << 0,
        /// <summary>
        /// <para>Группа объединилась с другой</para>
        /// </summary>
        TroopMergedWithThis = 1 << 1,
        /// <summary>
        /// <para>???</para>
        /// </summary>
        Unknown02 = 1 << 2,
        /// <summary>
        /// <para>???</para>
        /// </summary>
        Unknown03 = 1 << 3,
        /// <summary>
        /// <para>Группа преобразует укрепление в съетч</para>
        /// </summary>
        FortressRebuildIntoSietch = 1 << 4,
        /// <summary>
        /// <para>Группа умеет собирать спайс</para>
        /// </summary>
        SpiceSkilled = 1 << 5,
        /// <summary>
        /// <para>Группа умеет воевать</para>
        /// </summary>
        MilitarySkilled = 1 << 6,
        /// <summary>
        /// <para>Группа знает экологию</para>
        /// </summary>
        EcologySkilled = 1 << 7,
    }
}
