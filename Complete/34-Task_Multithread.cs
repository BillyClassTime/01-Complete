using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Complete
{
    class MultithreadExample
    {
        static void Main()
        {
            // First Instanciation of class MyAsync
            var da = new MyAsync();
            Task t1 = new Task(new Action(da.SlowAction));
            Task t2 = new Task(delegate 
                            {
                                da.ShowMethod("Called from Delegate");
                            });
            Task t3 = new Task(() => 
                            {
                                da.ShowMethod("Called form Lampda Expression");
                            });
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
    class MyAsync
    {
        internal void SlowAction()
        {
            ShowMethod("Called from Action");
        }
        internal void ShowMethod(string message)
        {
            Thread.Sleep(200);
            Console.WriteLine($"To {DateTime.Now.ToLongDateString().ToString()} {message} ");
        }
    }
}
