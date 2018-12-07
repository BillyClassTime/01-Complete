﻿using System;

namespace _01_Complete
{

    class EventosYDelegadosDatos
    {
        static void Main()
        {
            var c = new Counter_(new Random().Next(10));
            c.ThresholdReached += C_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
            Console.WriteLine("..Fin del programa, precione cualquier tecla para continuar");
            Console.ReadLine();
        }

        static void C_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"The threshold of {e.Threshold} was reached at {e.TimeReached}.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    class Counter_
    {
        private int threshold;
        private int total;

        public Counter_(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                var args = new ThresholdReachedEventArgs
                {
                    Threshold = threshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            var handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}

