using System;


namespace _01_Complete
{
    class Variables
    {
        static void Main()
        {
            Console.WriteLine("What is your name?");
            Console.WriteLine("Type your first name:");
            string myFirstName;
            myFirstName = Console.ReadLine();
            Console.Write("Type your last name:");
            var myLastName = Console.ReadLine();
            Console.WriteLine($"Hello, {myFirstName} {myLastName} {"nice to see you!"}");
            Console.WriteLine($"Hello {myFirstName} {myLastName} {"Nice to see you!"} ");
            Console.ReadLine();
            myLastName = string.Empty;
            concatenacion(myFirstName, out myLastName);
        }

        private static void concatenacion(string myFirtsName, out string v)
        {
            v = string.IsNullOrEmpty(myFirtsName) ? "Apellido en blanco" : $"{myFirtsName} no esta en blanco";
            return;
        }
    }
}
