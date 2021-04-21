namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Субрегионы (вторая часть названия поселения)</para>
    /// </summary>
    public enum DuneSubRegions : byte
    {
        /// <summary>
        /// <para>Не определен.</para>
        /// </summary>
        /// <remarks>
        /// <para>Нельзя использовать в сохраненном файле</para>
        /// </remarks>
        None = 0x00,
        /// <summary>
        /// <para>Атридес (используется только в названии дворца)</para>
        /// </summary>
        Atreides /* 0x01 */,
        /// <summary>
        /// <para>Харконнен (используется только в названии дворца)</para>
        /// </summary>
        Harkonnen /* 0x02 */,
        /// <summary>
        /// <para>Табр</para>
        /// </summary>
        /// <remarks>
        /// <para>Вообще, на Дюне был всего один ситч Табр...</para>
        /// </remarks>
        Tabr /* 0x03 */,
        /// <summary>
        /// <para>Тимин</para>
        /// </summary>
        Timin /* 0x04 */,
        /// <summary>
        /// <para>Туек</para>
        /// </summary>
        Tuek /* 0x05 */,
        /// <summary>
        /// <para>Харг</para>
        /// </summary>
        Harg /* 0x06 */,
        /// <summary>
        /// <para>Клам</para>
        /// </summary>
        Clam /* 0x07 */,
        /// <summary>
        /// <para>Цимин</para>
        /// </summary>
        Tsymyn /* 0x08 */,
        /// <summary>
        /// <para>Сьет</para>
        /// </summary>
        Siet /* 0x09 */,
        /// <summary>
        /// <para>Пейонс (используется в названиях баз контрабандистов)</para>
        /// </summary>
        /// <remarks>
        /// <para>Хотя, в книге, пеоны - оседлые жители Дюны, по сути, поселения рабов.</para>
        /// </remarks>
        Pyons /* 0x0a */,
        /// <summary>
        /// <para>Пиорт</para>
        /// </summary>
        Pyort /* 0x0b */,
    }
}
