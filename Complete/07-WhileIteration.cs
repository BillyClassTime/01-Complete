using System;

namespace _01_Complete
{
    #region WhileIteration
    class WhileIteration
    {
        #region Main
        static void Main()
        {
            var displayMenu = true;
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
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Print Numbers");
            Console.WriteLine("2) Guessing Game");
            Console.WriteLine("3) Exit");
            Console.WriteLine(new string('-', 30));
            var result = Console.ReadLine();
            //int operacion=1; The difference between ref and out parameters
            if (result == "1")
            {
                //PrintNumbers(ref operacion);
                PrintNumbers(out int operacion);
                return true;
            }
            else if (result == "2")
            {
                GuessingGame();
                return true;
            }
            else return result == "3" ? false : true;

        }
        #endregion
        #region Statics Methods
        private static void GuessingGame()
        {
            Console.Clear();
            Console.WriteLine("Guessing game!!");

            var myRandom = new Random();
            var randomNumber = myRandom.Next(1, 11);
            var guesses = 0;
            var incorrect = true;
            do
            {
            Console.WriteLine("Guest a nubmer between 1 and 10:");
                var result = Console.ReadLine();
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
        //private static void PrintNumbers(ref int number)
        private static void PrintNumbers(out int number)
        {
            Console.Clear();
            Console.WriteLine("Print numbers!");
            Console.Write("Type a number:");
            var resultado = int.Parse(Console.ReadLine());
            var contador = 1;
            var line = "";
            while (contador < resultado + 1)
            {
                Console.Write("{0:000}", contador);
                contador++;
                line = (contador == resultado + 1) ? "\n" : "-";
                Console.Write($"{line}");
            }
            number = contador;
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        #endregion
    }
    #endregion
}
