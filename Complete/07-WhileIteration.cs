using System;

namespace _01_Complete
{
    #region WhileIteration
    class WhileIteration
    {
        #region Main
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }
        #endregion
        #region MainMenu
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Print Numbers");
            Console.WriteLine("2) Guessing Game");
            Console.WriteLine("3) Exit");
            string result = Console.ReadLine();
            if (result=="1")
            {
                PrintNumbers();
                return true;
            }
            else if (result=="2")
            {
                GuessingGame();
                return true;
            }
            else if (result=="3")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion
        #region Statics Methods
        private static void GuessingGame()
        {
            Console.Clear();
            Console.WriteLine("Guessing game!!");

            Random myRandom = new Random();
            int randomNumber = myRandom.Next(1, 11);
            int guesses = 0;
            bool incorrect = true;
            do
            {
                Console.WriteLine("Guest a nubmer between 1 and 10:");
                string result = Console.ReadLine();
                guesses++;
                if (result == randomNumber.ToString())
                {
                    incorrect = false;
                }
                else
                    Console.WriteLine("Wrong!");
            } while (incorrect);
            Console.WriteLine($"Correct! It took you {guesses} guesess.");
            Console.ReadLine();
        }

        private static void PrintNumbers()
        {
            Console.Clear();
            Console.WriteLine("Print numbers!");
            Console.Write("Type a number:");
            int resultado = int.Parse(Console.ReadLine());
            int contador = 1;
            string line = "";
            while (contador < resultado + 1 )
            {
                Console.Write("{0:000}",counter);
                counter++;
                line = (counter == result+1) ? "\n" : "-";
                Console.Write($"{line}");
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        #endregion
    }
    #endregion
}
