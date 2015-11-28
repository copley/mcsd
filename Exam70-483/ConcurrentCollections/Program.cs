using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    class Program
    {
        private static readonly ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("### ConcurrentQueue Example ###");
            RunConcurrentQueueExample();
            Console.ReadKey();
        }

        private static void RunConcurrentQueueExample()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            int result;
            queue.TryDequeue(out result);
            Console.WriteLine(result);
            queue.TryDequeue(out result);
            Console.WriteLine(result);
            queue.TryDequeue(out result);
            Console.WriteLine(result);
        }
    }
}
