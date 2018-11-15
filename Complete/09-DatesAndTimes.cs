using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01_Complete
{
    class DatesAndTimes
    {
        static void Main(string[] args)
        {
            DateTime myValue = DateTime.Now;
            Console.WriteLine(myValue.ToString());
            int currentForegroundColor = (int)Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"ToShortDateString:{myValue.ToShortDateString()} " +
                $"\nToShortTimeString:{myValue.ToShortTimeString()}");
            Console.ForegroundColor = (ConsoleColor)currentForegroundColor;
            Console.WriteLine($"ToLongDateString:{myValue.ToLongDateString()}" +
                $"\nToLongTimeString:{myValue.ToLongTimeString()}");
            Console.WriteLine($"AddDays:{myValue.AddDays(3).ToLongTimeString()}" +
                $"\nAddHours:{myValue.AddHours(3)}-");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Month:{myValue.Month}");
            DateTime myBirthday = new DateTime(1968, 12, 31);
            Console.WriteLine(myBirthday.ToShortDateString());
            //Format of DateTime.Parse("dia/mes/año");
            myBirthday = DateTime.Parse("31/12/1968");
            //Represent a interval of time
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            Console.WriteLine(myAge.TotalDays);
            string dateInput = "Dec 21, 2018"; // Esto no funciona si la cadena es "Dic 21, 2018"
            DateTime parsedDated = DateTime.Parse(dateInput);
            Console.WriteLine("{0}", parsedDated);
            CultureInfo myCultureInfo = new CultureInfo("es-ES");
            string mySpanishDate = "21 Diciembre 2018";
            DateTime myDateTime = DateTime.Parse(mySpanishDate, myCultureInfo);
            Console.WriteLine("{0}", myDateTime.ToShortDateString());
            Console.ReadLine();
        }       
    }
}
