using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuationTasks
{
    class Program
    {
        // For more details see https://msdn.microsoft.com/en-us/library/ee372288.aspx

        static void Main(string[] args)
        {
            // Execute the antecedent.
            Task<DayOfWeek> taskA = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return DateTime.Today.DayOfWeek;
            });

            Console.WriteLine("Determining current day of week...");

            // Execute the continuation when the antecedent finishes.
            Task continuation = taskA.ContinueWith(antecedent => Console.WriteLine("Today is {0}.", antecedent.Result));

            Console.ReadKey();
        }
    }
}
