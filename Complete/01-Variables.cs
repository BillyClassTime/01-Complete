using System;


namespace _01_Complete
{
    class Variables
    {
        static void Main(string[] args)
        {
            //int x;
            //int y;
            //x = 7;
            //y = x + 3;
            //Console.WriteLine(y);
            //Console.ReadLine();
            Console.WriteLine("What is your name?");
            Console.WriteLine("Type your first name:");
            string myFirstName;
            myFirstName = Console.ReadLine();
            Console.Write("Type your last name:");
            string myLastName = Console.ReadLine();
            Console.WriteLine($"Hello, {myFirstName} {myLastName} " +
                $"{"nice to see you!"}");
            Console.WriteLine("Hello {0} {1} {2} ", myFirstName, myLastName, 
                "Nice to see you!");
            Console.ReadLine();
        }
    }
}
