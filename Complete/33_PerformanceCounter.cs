using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class PerformancesCounters
    {
        public static void Main()
        {
            ReadingWebData();
            Counter();
            IncrementCounter();
            ReadingWebData();
            Counter();
            IncrementCounter();
            ReadingWebData();
            Counter();
            IncrementCounter();
        }
        private static void Counter()
        {
            if (!PerformanceCounterCategory.Exists("A Demo counter"))
            {
                var counters = new CounterCreationDataCollection();
                var totalReads = new CounterCreationData();
                totalReads.CounterName = "Web readers data";
                totalReads.CounterHelp = "Total numbers of readers done";
                totalReads.CounterType = PerformanceCounterType.NumberOfItems32;
                counters.Add(totalReads);
                PerformanceCounterCategory.Create("A Demo counter", "A Category for demostration",
                PerformanceCounterCategoryType.SingleInstance, counters);
            }
        }
        private static void IncrementCounter()
        {
            var CounterReader = new PerformanceCounter("A Demo counter",
                "Web readers data", false);
            CounterReader.Increment();
            CounterReader.Dispose();
        }
        private static void ReadingWebData()
        {
            var text = string.Format("{0} {1}", "Performance Monitor: A simple example to write ",
                   "data into a file saved in disk");
            System.Console.WriteLine(text);
            File.WriteAllText(
            @"C:\Exer\All\01-Complete\Complete\WriteText.txt", text);
            //System.Console.ReadLine();

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
