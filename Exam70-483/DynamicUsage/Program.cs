using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# With anonymous type");
            dynamic d1 = new { Name = "Roman", Country = "Switzerland" };
            Console.WriteLine(d1.Name);
            Console.WriteLine(d1.Country);

            Console.WriteLine("# With ExpandoObject");
            dynamic d2 = new ExpandoObject();
            d2.Name = "Roman";
            d2.Country = "Switzerland";
            Console.WriteLine(d2.Name);
            Console.WriteLine(d2.Country);

            Console.ReadKey();
        }
    }
}
