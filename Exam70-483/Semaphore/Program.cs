using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphore
{
    class Program
    {
        private static readonly object _syncObject = new object();
        
        // maximum 5 persons can enter the club
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(5);

        private static readonly Random _random = new Random();

        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(DoorManService).Start(i);
            }

            Console.ReadLine();
        }

        private static void DoorManService(object id)
        {
            WriteYellowLine("Partier {0} wants to enter the night club...", id);
            _semaphore.Wait();
            WriteGreenLine("The doorman has let partier {0} enter the night club...", id);
            for (int i = 0; i < _random.Next(2, 5); i++)
            {
                WriteWhiteLine("Partier {0} is dancing...", id);
                Thread.Sleep(100);
            }
            WriteRedLine("Partier {0} has left the club", id);
            _semaphore.Release();
        }
        
        private static void WriteGreenLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine(format, arg);
            }
        }

        private static void WriteLine(string format, object arg)
        {
            Console.WriteLine(format, arg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteYellowLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                WriteLine(format, arg);
            }
        }

        private static void WriteRedLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine(format, arg);
            }
        }

        private static void WriteWhiteLine(string format, object arg)
        {
            lock (_syncObject)
            {
                Console.ForegroundColor = ConsoleColor.White;
                WriteLine(format, arg);
            }
        }
    }
}
