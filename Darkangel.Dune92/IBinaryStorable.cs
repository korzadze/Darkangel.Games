using System.IO;

namespace Darkangel.Dune92
{
    public interface IBinaryStorable
    {
        void Store(Stream stream);
    }
}
