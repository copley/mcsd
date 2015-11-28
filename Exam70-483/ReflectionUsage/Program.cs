using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog { NumberOfLegs = 4 };

            Type t1 = typeof(Dog);
            Type t2 = dog.GetType();

            Console.WriteLine(t2.Name);
            Console.WriteLine(t2.Assembly);

            var newDog = (Dog)Activator.CreateInstance(typeof(Dog));
            var genericDog = Activator.CreateInstance<Dog>();

            var defaultConstructor = typeof(Dog).GetConstructor(new Type[0]);
            var legConstructor = typeof(Dog).GetConstructor(new[] { typeof(int) });
            var defaultDog = (Dog)defaultConstructor.Invoke(null);
            var fiveLegDog = (Dog)legConstructor.Invoke(new object[] { 5 });
            Console.WriteLine(fiveLegDog.NumberOfLegs);

            var p1 = t1.GetProperty("NumberOfLegs");
            var v1 = p1.GetValue(dog);
            Console.WriteLine("NumberOfLegs = " + v1);

            var m1 = t1.GetMethod("Speak");
            var v2 = m1.Invoke(dog, null);
            Console.WriteLine("The dog speaks: " + v2);

            Console.ReadKey();
        }
    }

    class Dog
    {
        public int NumberOfLegs { get; set; }

        public string Speak()
        {
            return "Wuff!";
        }

        public Dog()
        {
            NumberOfLegs = 4;
        }

        public Dog(int legs)
        {
            NumberOfLegs = legs;
        }
    }
}
