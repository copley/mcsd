using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### Parallel.For ###");
            RunParallelFor();
            Console.WriteLine("Press key to proceed");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("### Parallel.ForEach ###");
            RunParallelForEach();
            Console.WriteLine("Press key to proceed");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("### Plinq ###");
            RunPlinq();
            Console.WriteLine("Press key to proceed");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("### Task ###");
            RunTask();
            Console.WriteLine("Press key to exit");
            Console.ReadKey();
        }

        private static void RunParallelForEach()
        {
            var numbers = Enumerable.Range(1, 100);
            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine("ParallelForEach Iteration " + i);
            });
        }

        private static void RunParallelFor()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions options = new ParallelOptions()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = 4
            };
            // Iterates from 1..99
            Parallel.For(1, 100, options, i =>
            {
                Console.WriteLine("ParallelFor Iteration " + i);
            });
        }

        private static void RunPlinq()
        {
            var source = Enumerable.Range(100, 20000);

            // Result sequence might be out of order.
            var parallelQuery = from num in source.AsParallel()
                                where num % 10 == 0
                                select num;

            // Process result sequence in parallel
            parallelQuery.ForAll(i =>
            {
                Console.WriteLine("Plinq Iteration " + i);
            });

            // Or by extension methods
            // var parallelQuery2 = source.AsParallel().Where(n => n % 10 == 0).Select(n => n);
        }

        private static void RunTask()
        {
            Task t = Task.Run(() => {
                // Just loop.
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            });
            t.Wait();
        }
    }
}
