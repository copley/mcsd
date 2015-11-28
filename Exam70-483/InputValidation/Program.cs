using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat();
            Animal dog = new Dog();

            try
            {
                cat.SetName(string.Empty); // throws
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                cat.SetName("Miautzi");
                cat.SetName("Miautzi"); // throws
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                cat.SetName("TooLongNameForACat"); // throws
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        public abstract class Animal
        {
            public string Name { get; protected set; }
            public abstract void SetName(string value);
        }

        public class Cat : Animal
        {
            public override void SetName(string value)
            {
                // validate empty
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("value");

                // validate conflict
                if (value == this.Name)
                    throw new ArgumentException("value is duplicate");

                // validate size
                if (value.Length > 10)
                    throw new ArgumentException("value is too long");

                this.Name = value;
            }
        }

        public class Dog : Animal
        {
            public override void SetName(string value)
            {
                // validate input
                Contract.Requires(!string.IsNullOrWhiteSpace(value), "value is empty");
                this.Name = value;
            }

            public string GetName()
            {
                // validate output
                Contract.Ensures(!string.IsNullOrWhiteSpace(Contract.Result<string>()));
                return this.Name;
            }
        }
    }
}
