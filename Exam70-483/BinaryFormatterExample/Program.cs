using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFormatterExample
{
    class Program
    {
        private const string filename = "data.dat";

        static void Main(string[] args)
        {
            // Delete old file, if it exists
            if (File.Exists(filename))
            {
                Console.WriteLine("Deleting old file");
                File.Delete(filename);
            }

            Animal a1 = new Animal()
            {
                Name = "Roman",
                NumberOfLegs = 2
            };

            // Persist to file
            FileStream stream = File.Create(filename);
            var formatter = new BinaryFormatter();
            Console.WriteLine("Serializing Animal");
            formatter.Serialize(stream, a1);
            stream.Close();

            Console.WriteLine();
            Console.WriteLine("Contents of " + filename);
            Console.WriteLine(File.ReadAllText(filename));
            Console.WriteLine();

            // Restore from file
            stream = File.OpenRead(filename);
            Console.WriteLine("Deserializing animal");
            Animal a2 = (Animal)formatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("Deserialized Animal: Name = " + a2.Name + ", NumberOfLegs = " + a2.NumberOfLegs);
            Console.WriteLine("Press Enter Key");
            Console.Read();
        }
    }

    [Serializable]
    public class Animal
    {
        public string Name { get; set; }
        public int NumberOfLegs { get; set; }
    }
}
