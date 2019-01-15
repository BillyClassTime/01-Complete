using System;
using System.Diagnostics;
using System.Text;
namespace _01_Complete
{
    public class PerformaceOperationString
    {
        public static void Main()
        {
            Console.WriteLine("Performance of concatenation");
            var pr = new PerformaceOperationString();
            var stopWatch = new Stopwatch();
            string string1, string2, string3;
            string1 = new string('A', 15000);
            string2 = new string('a', 15000);
            stopWatch.Start();
            //string3 = String.Format("{0}{1}", string1, string2);
            string3 = $"{string1}{string2}";
            //string3 = $"{string1}{new string('a', 14999)}";
            stopWatch.Stop();
            //pr.ShowTimes(stopWatch, "string3 = String.Format(\"{0}{1}\", string1, string2)");
            pr.ShowTimes(stopWatch, "string3 = $\"{string1}{string2}");
            stopWatch.Start();
            var result = pr.StringCompare(string1, string2, string3);
            stopWatch.Stop();
            Console.WriteLine((result ? true : false).ToString());
            stopWatch.Start();
            result = pr.StringCompare(string1, string2, string3, false);
            stopWatch.Stop();
            pr.ShowTimes(stopWatch, "Comparando con StringBuilder and ToUpper() ==");
            //pr.ShowTimes(stopWatch, "Comparando con adding string");
            Console.WriteLine((result ? true : false).ToString());
            Console.ReadLine();
        }
        public bool StringCompare(string string1, string string2, string string3)
        {
            var concatStrings = new StringBuilder(string1);
            concatStrings.Append(string2);
            //var result = (concatStrings.ToString().ToUpper() == string3.ToUpper());
            var result = concatStrings.ToString().Equals(string3, StringComparison.CurrentCultureIgnoreCase);
            return result;
        }
        public bool StringCompare(string string1, string string2, string string3, bool other = true)
        {
            var concatStrings = new StringBuilder(string1); concatStrings.Append(string2);
            //var concatStrings = string1 + string2;
            var result = (concatStrings.ToString().ToUpper() == string3.ToUpper());
            //var result = concatStrings.ToString().Equals(string3, StringComparison.CurrentCultureIgnoreCase);
            return result;
        }
        public void ShowTimes(Stopwatch stopWatch, string message)
        {
            // Get the elapsed time as a TimeSpan value.
            var ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000000000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds );
            Console.WriteLine($"RunTime:{message}->{elapsedTime}");
        }
    }
}
