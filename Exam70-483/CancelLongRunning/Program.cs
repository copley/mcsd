using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelLongRunning
{
    class Program
    {
        static void Main(string[] args)
        {
            // start with cancel option
            var source = new CancellationTokenSource();
            LongRunning(source.Token);
            
            Thread.Sleep(1000);
            
            source.Cancel();
            Console.WriteLine("Cancelled");

            Console.Read();
        }

        static async void LongRunning(CancellationToken token)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("{0} {1}", i, stopwatch.Elapsed.TotalMilliseconds);
                await Task.Delay(new Random().Next(3, 100));
                if (token.IsCancellationRequested)
                    break;
            }
        }
    }
}
