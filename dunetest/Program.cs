using System;
using System.IO;
using Darkangel.Dune92;

namespace dunetest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var fname in args)
                {
                    SaveGame sg = new(args[0]);
                    var xname = Path.GetFileNameWithoutExtension(fname) + ".xml";
                    sg.ToXml().Save(xname);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.GetType().FullName);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Stack: {0}", ex.StackTrace);
            }
        }
    }
}
