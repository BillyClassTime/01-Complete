using System;
using System.Timers;

namespace _01_Complete
{
    class TimerExample
    {
        static void Main()
        {
            using (var myTimer = new Timer(2000))
            {
                myTimer.Elapsed += MyTimer_Elapsed;
                myTimer.Elapsed += MyTimer_Elapsed1;
                myTimer.Elapsed += MyTimer_Elapsed2;

                myTimer.Start();
                EscribirYEsperar("White");
                myTimer.Elapsed -= MyTimer_Elapsed1;
                EscribirYEsperar("Magenta");
                myTimer.Elapsed -= MyTimer_Elapsed2;
                EscribirYEsperar("Exit");
                myTimer.Elapsed -= MyTimer_Elapsed;
            }
        }

        private static void EscribirYEsperar(string v)
        {
            if (string.IsNullOrWhiteSpace(v))
            {
                throw new ArgumentException("message", nameof(v));
            }

            Console.ForegroundColor = ConsoleColor.White;
            if (string.Compare(v, "Exit") == 0)
            {
                Console.WriteLine("Press enter in any moment, to exit...");
            }
            else
            {
                Console.WriteLine($"Press enter in any moment, to remove the {v} event....");

            }
            Console.ReadLine();
        }

        private static void MyTimer_Elapsed(object sender, ElapsedEventArgs e) //,int resultado = 0)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Elapsed1: {0:HH:mm:ss.fff}", e.SignalTime);
            Console.WriteLine($"Elapsed1: {e.SignalTime:HH:mm:ss.fff}");
        }

        private static void MyTimer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Elapsed: {e.SignalTime:HH:mm:ss.fff}");
        }
        private static void MyTimer_Elapsed2(object sender, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Elapsed: {e.SignalTime:HH:mm:ss.fff}");
        }
    }
    
}