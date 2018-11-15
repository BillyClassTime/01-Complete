using System;
namespace _01_Complete
{
    class UndestandingScopes
    {
        public  string k;
        static void Main(string[] args)
        {
            string j = "";
            UndestandingScopes program = new UndestandingScopes();
            for (int i = 0; i < 10; i++)
            {
                j = i.ToString();
                program.k = i.ToString();
                Console.WriteLine(i);
            }
            //Console.WriteLine(i); This variable is invalid because is out "for block" scope
            Console.WriteLine($"value of i:{j}");
            Console.WriteLine($"value of k:{program.k}");
            // Calling Car Class with its private and public methods
            Car_US car = new Car_US();
            Console.WriteLine("Calling car methods");
            car.DoSomething();
            Console.ReadLine();
        }
    }

    class Car_US
    {
        public void DoSomething()
        {
            Console.WriteLine(HelperMethod());
        }

        private string HelperMethod()
        {
            return "Hello world!";
        }
    }

}
