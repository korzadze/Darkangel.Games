using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Утилиты для получения списка файлов сохраненной игры</para>
    /// </summary>
    public static class SaveGameFactory
    {
        private static readonly Regex reSaveFile =
            new(@"DUNE(?<ver>\d{2})S(?<slot>\d{1})\.SAV",
                RegexOptions.IgnoreCase |
                RegexOptions.Singleline |
                RegexOptions.Compiled);
        /// <summary>
        /// <para>Получить список файлов сохраненной игры</para>
        /// </summary>
        /// <param name="path">Путь к корню игры</param>
        /// <returns>Список файлов</returns>
        public static IEnumerable<SaveInfo> GetFiles(string path)
        {
            var res = new List<SaveInfo>();
            foreach(var fname in Directory.EnumerateFiles(path, "*.SAV", SearchOption.TopDirectoryOnly))
            {
                var m = reSaveFile.Match(fname);
                if(m.Success)
                {
                    var slot = int.Parse(m.Groups["slot"].Value);
                    var ver = int.Parse(m.Groups["ver"].Value);
                    using FileStream rd = File.OpenRead(fname);
                    var hdr = new SaveHeader();
                    hdr.Load(rd);
                    res.Add(new SaveInfo(fname, ver, slot, hdr));
                }
            }
            return res;
        }
    }
}
