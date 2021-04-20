namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Информация о сохраненной игре</para>
    /// </summary>
    public class SaveInfo
    {
        /// <summary>
        /// <para>Имя файла сохраненной игры</para>
        /// </summary>
        public readonly string FileName;
        /// <summary>
        /// <para>Заголовок сохраненной игры</para>
        /// </summary>
        public readonly SaveHeader Header;
        /// <summary>
        /// <para>Слот сохранения</para>
        /// </summary>
        public readonly int Slot;
        /// <summary>
        /// <para>Название слота сохранения</para>
        /// </summary>
        public readonly string SaveName;
        /// <summary>
        /// <para></para>
        /// </summary>
        public readonly int Version;
        internal SaveInfo(string fileName, int version, int slot, SaveHeader header)
        {
            FileName = fileName;
            Header = header;
            Slot = slot;
            Version = version;
            SaveName = slot switch
            {
                0 => StringResources.Slot0Name,
                1 => StringResources.Slot1Name,
                2 => StringResources.Slot2Name,
                3 => StringResources.Slot3Name,
                4 => StringResources.Slot4Name,
                _ => StringResources.UnknownSlotName,
            };
        }
    }
}
