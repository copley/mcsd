using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolUsage
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Allow only 1 thread in the ThreadPool");
            
            // Queue the tasks.
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 2);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 3);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc), 4);
            
            Console.ReadKey();
        }

        // This thread procedure performs the task.
        private static void ThreadProc(object stateInfo)
        {
            var randomTime = random.Next(5000, 10000);
            Console.WriteLine("Hello from the thread pool " + stateInfo + ". I need " + randomTime + "ms to process.");
            Thread.Sleep(randomTime);
            Console.WriteLine("Thread " + stateInfo + " is finished.");
        }
    }
}
