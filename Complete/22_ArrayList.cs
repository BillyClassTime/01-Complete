using System;
using System.Collections;

namespace _01_Complete
{
    class ArrayListExamples
    {
        public static void Main()
        {
            // Creating and initialize a new ArrayList
            //ArrayList myAL = new ArrayList();
            //myAL.Add("Hello");
            //myAL.Add("World");
            //myAL.Add("!");

            var myAL = new ArrayList
            {
                "Hello",
                "World",
                "!"
            };


            //Display the properties and values of array List
            Console.WriteLine("myAl");

            Console.WriteLine($"    Count:{myAL.Count}");
            Console.WriteLine($"    Capacity:{myAL.Capacity}");
            Console.WriteLine("Values");
            PrintValues(myAL);
            IEnumerator e = myAL.GetEnumerator(0, 1);
            PrintAboutEnumerator(e);
        }

        private static void PrintAboutEnumerator(IEnumerator enu)
        {
          Console.WriteLine("myAL.GetEnumerator(0, 1);");
            while (enu.MoveNext())
            {
                var obj = enu.Current;
                Console.WriteLine(obj);
            }
            Console.WriteLine();
            Console.Write("Press any key to end...");
            Console.ReadLine();
        }

        private static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
            {
                Console.Write($"{obj} ");
            }
            Console.WriteLine();
            Console.Write("Press any key to end...");
            Console.ReadLine();
        }
    }
}
