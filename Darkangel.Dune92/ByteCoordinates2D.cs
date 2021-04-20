using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Dune92
{
    /// <summary>
    /// <para>Координаты</para>
    /// </summary>
    public class ByteCoordinates2D : IBinaryData
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
    }
}
