using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogUsage
{
    class Program
    {
        // THIS APPLICATION MUST BE RUN WITH ADMINISTRATOR PRIVILEGES
        // OTHERWISE AN EXCEPTION OCCURS!
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("MySource"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                Console.ReadKey();
                // The source is created.  Exit the application to allow it to be registered.
                // You can now see "MyNewLog" in the "Event Viewer" under "Application and Services Logs"
                return;
            }

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = "MySource";

            // Write an informational entry to the event log.    
            myLog.WriteEntry("Writing to event log.");
        }
    }
}
