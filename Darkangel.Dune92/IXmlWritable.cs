using System.Xml;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Интерфейс объектов, поддерживающих запись данных в XML</para>
    /// </summary>
    /// <remarks>Лень возится с сериализацией</remarks>
    public interface IXmlWritable
    {
        /// <summary>
        /// <para>Добавить информацию объекта к </para>
        /// </summary>
        /// <param name="owner"></param>
        void AppendTo(XmlElement owner);
    }
}
