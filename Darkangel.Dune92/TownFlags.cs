using System;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Флаги поселения</para>
    /// </summary>
    [Flags]
    public enum TownFlags
    {
        /// <summary>
        /// <para>В поселении начаты посадки</para>
        /// </summary>
        HasVegetationBegun = 1 << 0,
        /// <summary>
        /// <para>Поселение атаковано</para>
        /// </summary>
        UnderAttack = 1 << 1,
        /// <summary>
        /// <para>В поселение проникли агенты Харконненов</para>
        /// </summary>
        SietchInfiltrated = 1 << 2,
        /// <summary>
        /// <para>Битва за поселение выиграна</para>
        /// </summary>
        BattleWon = 1 << 3,
        /// <summary>
        /// <para>Поселение обследовано</para>
        /// </summary>
        Visited = 1 << 4,
        /// <summary>
        /// <para>В поселении установлены водяные ловушки</para>
        /// </summary>
        HasWindtrap = 1 << 5,
        /// <summary>
        /// <para>Район вокруг поселения исследован на залежи спайса</para>
        /// </summary>
        Prospected = 1 << 6,
        /// <summary>
        /// <para>Поселение еще не открыто</para>
        /// </summary>
        Hidden = 1 << 7,
    }
}
