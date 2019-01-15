using System;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Complete
{
    class Task_Chained
    {
        static void Main()
        {
            Task<string> t1 = new Task<String>(() =>
            {
                Thread.Sleep(2500);
                return "Task 1 complete";
            });

            //Task t2 = new Task((input) =>
            Task t2 = t1.ContinueWith((input) =>
             {
                 Console.WriteLine("Otro proceso en la tarea 2");
                 Console.WriteLine(input.Result);
                 Console.WriteLine("Task 2 Complete");
                 //}, "Task 2");
             });
            //change Task t2 = t1.ContinuedWith((input) => { Console:WriteLine(input.Result);
            //change for step 2 of demo to Console.WriteLine(“Task 2 Complete”);	
            // Change to only “};” with out question marks !
            //change Task t3 = t2.ContinuadWith() =>
            //Task t3 = new Task(() =>
            Task t3 = t2.ContinueWith((input) =>
            {
                Console.WriteLine("Task 3 Completed");
            });
            t1.Start();
            //t2.Start();             // n step 2 of demo do comment to this line
            //t3.Start();             // In step 2 of demo do comment to this line
            //Console.WriteLine(t1.Result); // In step 2 of demo do comment to this line

            Console.WriteLine("Done");
            Console.WriteLine($"After Done: {t1.Result}");
            Console.ReadLine();

        }
    }
}
