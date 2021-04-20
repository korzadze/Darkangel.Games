using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Dune92
{
    public class UnknownFieldData
    {
        public readonly byte[] Data;
        public void Load(Stream stream)
        {
            if (stream.Read(Data, 0, Data.Length) != Data.Length)
            {
                throw new EndOfStreamException();
            }
        }
        public void Store(Stream stream)
        {
            stream.Write(Data, 0, Data.Length);
        }
        internal UnknownFieldData(long dataSize)
        {
            Data = new byte[dataSize];
        }
    }
}
