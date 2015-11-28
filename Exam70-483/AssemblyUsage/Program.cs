using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = Assembly.GetExecutingAssembly();
            var t1 = a1.GetType("AssemblyUsage.Program");
            Console.WriteLine("LOADED: " + t1.AssemblyQualifiedName);

            var a2 = Assembly.LoadFrom(Path.Combine(Directory.GetCurrentDirectory(), "DummyLibrary.dll"));
            var t2 = a2.GetType("DummyLibrary.Class1");
            Console.WriteLine("LOADED: " + t2.AssemblyQualifiedName);

            Console.ReadKey();
        }
    }
}
