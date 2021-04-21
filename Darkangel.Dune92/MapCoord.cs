using Darkangel.Xml;
using System.IO;
using System.Xml;

namespace Darkangel.Games.Dune92
{
    /// <summary>
    /// <para>Координаты</para>
    /// </summary>
    public class MapCoord : IBinaryData, IXmlWritable
    {
        /// <summary>
        /// <para>Координата X</para>
        /// </summary>
        public byte X;
        /// <summary>
        /// <para>Координата Y</para>
        /// </summary>
        public byte Y;
        /// <inheritdoc/>
        public void Load(Stream stream)
        {
            X = (byte)stream.ReadByte();
            Y = (byte)stream.ReadByte();
        }
        /// <inheritdoc/>
        public void Store(Stream stream)
        {
            stream.WriteByte(X);
            stream.WriteByte(Y);
        }
        /// <inheritdoc/>
        public void AppendTo(XmlElement owner) =>
            owner.AddChild(nameof(MapCoord))
                .AddAttribute(nameof(X), X)
                .AddAttribute(nameof(Y), Y);
    }
}
