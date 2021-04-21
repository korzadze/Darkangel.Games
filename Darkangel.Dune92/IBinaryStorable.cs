using System.IO;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Интерфейс объекта, допускающего сохранение данных в двоичном потоке</para>
    /// </summary>
    public interface IBinaryStorable
    {
        /// <summary>
        /// <para>Сохранить данные объекта в двоичный поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        void Store(Stream stream);
    }
}
