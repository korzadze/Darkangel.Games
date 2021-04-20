namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Расположение групп вокруг поселения на карте</para>
    /// </summary>
    public enum TroopPosition : byte
    {
        /// <summary>
        /// <para>Не определено</para>
        /// </summary>
        Undefined = 0x00,
        /// <summary>
        /// <para>В центре снизу</para>
        /// </summary>
        BottomCenter /* 0x01 */,
        /// <summary>
        /// <para>Справа снизу</para>
        /// </summary>
        BottomRight /* 0x02 */,
        /// <summary>
        /// <para>Слева снизу</para>
        /// </summary>
        BottomLeft /* 0x03 */,
        /// <summary>
        /// <para>Справа по центру</para>
        /// </summary>
        CenterRight /* 0x04 */,
        /// <summary>
        /// <para>Слева по центру</para>
        /// </summary>
        CenterLeft /* 0x05 */,
        /// <summary>
        /// <para>Справа сверху</para>
        /// </summary>
        TopRight /* 0x06 */,
        /// <summary>
        /// <para>Слева сверху</para>
        /// </summary>
        TopLeft /* 0x07 */,
        /// <summary>
        /// <para>В центре сверху</para>
        /// </summary>
        TopCenter /* 0x08 */
    }
}
