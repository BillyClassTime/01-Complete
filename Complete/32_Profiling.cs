using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class Profiling
    {
        public static void Main()
        {
            Logging("After reading data from web site");
            ReadingWebData();
            Console.ReadLine();
            Logging("Finalizing read");
            Console.ReadLine();
        }

        private static void Logging(string Message)
        {
            var eventLog = "Application";
            var eventSource = "Logging Demo";
            var eventMessage = Message;
            // Create the event source if it does not already exist.
            if (!EventLog.SourceExists(eventSource))
            {
                EventLog.CreateEventSource(eventSource, eventLog);
            }
            // Log the message.
            EventLog.WriteEntry(eventSource, eventMessage);
        }
        private static void ReadingWebData()
        {
            var text = string.Format("{0} {1}", "A simple example to write ",
                   "data into a file saved in disk");
            System.Console.WriteLine(text);
            File.WriteAllText(
            @"C:\Exer\All\01-Complete\Complete\WriteText.txt", text);
            System.Console.ReadLine();

            var client = new WebClient();
            var reply = client.DownloadString("http://msdn.microsoft.com");
            Console.WriteLine(reply);
            string path;
            path = $"{@"C:\Exer\All\01-Complete\Complete\"}{"DownloadInformation.txt"}";
            client.Dispose();
            File.WriteAllText(path, reply);
        }
    }
}
