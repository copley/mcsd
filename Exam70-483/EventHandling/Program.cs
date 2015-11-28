using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class Program
    {
        public delegate void SpeakEventHandler(string text);

        static void Main(string[] args)
        {
            var x = new Animal();
            
            x.OnSpeak += MySpeakMethod;
            x.OnSpeak += (text) => { Console.WriteLine(text); };
            x.OnSpeak += delegate (string text) { Console.WriteLine(text); };

            Console.WriteLine("Before");
            Console.WriteLine(string.Empty);
            
            x.Speak("Hello!");

            Console.WriteLine(string.Empty);
            Console.WriteLine("After");

            Console.Read();
        }

        private static void MySpeakMethod(string text)
        {
            Console.WriteLine(text);
        }

        public class Animal
        {
            public event SpeakEventHandler OnSpeak;
            
            public void Speak(string text)
            {
                if (OnSpeak != null)
                    OnSpeak(text);  
            }
        }
    }
}
