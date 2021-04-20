using System.IO;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Интерфейс объекта, допускающего загрузку из двоичного потока</para>
    /// </summary>
    public interface IBinaryLoadable
    {
        /// <summary>
        /// <para>Загрузить данные объекта из двоичного потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        void Load(Stream stream);
    }
}
