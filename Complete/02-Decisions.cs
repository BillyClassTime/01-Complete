using System;

namespace _01_Complete
{
    class Decisions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Billy, Big Giveaway");
            Console.Write("Choose a door: 1,2 or 3:");
            string userValue = Console.ReadLine();
            string message = "";
            if (userValue =="1")
            {
                message = " you won a new car!";
            }
            else if (userValue=="2")
            {
                message = " you won a new boat!";
            }
            else if (userValue=="3")
            {
                message = " you won a new jorney!";
            }
            else 
            {
                message = " you did not win anything!";
            }
            Console.WriteLine($"You enter:{userValue},{message}");
            Console.ReadLine();
        }
    }
}
