using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class UndestandingArrays
    {
        static void Main(string[] args)
        {
            int number1 = 4;
            int number2 = 8;
            int number3 = 24;
            int number4 = 32;
            int number5 = 40;
            int number6 = 48;
            int number7 = 64;
            Console.WriteLine(number1);
            Console.WriteLine(number2);
            Console.WriteLine(number3);
            if (number1 == 4)
            {
                Console.WriteLine($"number is {number4}");
            }
            Console.WriteLine(number5);
            Console.WriteLine(number6);
            Console.WriteLine(number7);
            Console.ReadLine();

            int[] numbers = new int[8];
            // Option 1
            numbers[0] = 2;
            numbers[1] = 4;
            numbers[2] = 8;
            numbers[3] = 24;
            numbers[4] = 32;
            numbers[5] = 40;
            numbers[6] = 48;
            numbers[7] = 68; /**/
            // Option 2 better and cleanest
            numbers = new int[] { 2, 4, 8, 24, 32, 40, 48, 68 };

            foreach (var number in numbers)
            {
                Console.WriteLine($"The numbers is:{number}");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"The position in array[{i}] has the value " +
                    $"{numbers[i]}");
            }
            string[] names = new string[] { "Eddie", "Alex", "Michael",
                "David Lee" };
            foreach (string name in names)
            {
                Console.WriteLine($"The name is:{name}");
            }


            string zig = "You can get what you want out of life " +
            " if you help enough other people get what they want.";
         
            char[] charArray = zig.ToCharArray();
            Array.Reverse(charArray);
            int colorActual = (int) Console.ForegroundColor;
            Console.WriteLine($"Cadena zig:{"\n"}{zig}");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            
            foreach (char zigChar in charArray)
            {
                Console.Write(zigChar);
            }
            Console.ForegroundColor = (System.ConsoleColor) colorActual;
            
            string cadenaDeTexto = "Cadena de texto a volver de revez";
            Console.WriteLine($"{"\n"}CadenaDeTexto:{"\n"}{cadenaDeTexto}");
            char[] cadena = cadenaDeTexto.ToCharArray();
            Array.Reverse(cadena);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var caracter in cadena)
            {
                Console.Write(caracter);
            }
            Console.ReadLine();
        }
    }
}
