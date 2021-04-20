using System.IO;

namespace Darkangel.Dune92
{
    public interface IBinaryLoadable
    {
        void Load(Stream stream);
    }
}
