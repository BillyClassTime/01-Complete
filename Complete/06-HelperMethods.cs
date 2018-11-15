using System;


namespace _01_Complete
{
    class HelperMethods
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The name Game");

            Console.Write("What's your first name?");
            string firstName = Console.ReadLine();

            Console.Write("What's your last name?");
            string lastName = Console.ReadLine();

            Console.Write("In what city where you born?");
            string city = Console.ReadLine();

            DisplayResult(firstName, lastName, city);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            DisplayResult(ReverseString(firstName), ReverseString(lastName), 
                ReverseString(city));
            Console.ReadLine();
        }
        private static void DisplayResult(string firstName, string lastName, 
            string city)
        {
            Console.WriteLine($"Results:{firstName} {lastName} {city}");
        }
        private static string ReverseString(string message)
        {
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }
    }
}
