using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class Profiling
    {
        public static void Main()
        {
            Logging();
            Console.ReadLine();
        }

        private static void Logging()
        {
            var eventLog = "Application";
            var eventSource = "Logging Demo 1";
            var eventMessage = "Hello from the Logging Demo application";
            // Create the event source if it does not already exist.
            if (!EventLog.SourceExists(eventSource))
            {
                EventLog.CreateEventSource(eventSource, eventLog);
            }
            // Log the message.
            EventLog.WriteEntry(eventSource, eventMessage);
        }
    }
}
