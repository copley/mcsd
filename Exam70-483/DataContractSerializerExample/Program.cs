using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContractSerializerExample
{
    class Program
    {
        // Add reference to System.Runtime.Serialization

        const string filename = "file.txt";

        static void Main(string[] args)
        {
            if (File.Exists(filename))
                File.Delete(filename);

            Animal a = new Animal()
            {
                Name = "Roman",
                NumberOfLegs = 2
            };

            Console.WriteLine("Original");
            Console.WriteLine(a.ToString());

            FileStream writeStream = File.Create(filename);
            DataContractSerializer serializer = new DataContractSerializer(typeof(Animal));
            serializer.WriteObject(writeStream, a);
            writeStream.Close();

            Console.WriteLine("Contents of " + filename);
            Console.WriteLine(File.ReadAllText(filename));

            FileStream readStream = File.OpenRead(filename);
            Animal deserialized = (Animal)serializer.ReadObject(readStream);

            Console.WriteLine("Deserialized");
            Console.WriteLine(deserialized.ToString());

            Console.ReadKey();
        }
    }


    [DataContract]
    public class Animal
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NumberOfLegs { get; set; }

        // This property will not be serialized
        public string Nickname { get; set; }

        public override string ToString()
        {
            return string.Format("[Animal] Name = {0}, NumberOfLegs = {1}", Name, NumberOfLegs);
        }
    }
}
