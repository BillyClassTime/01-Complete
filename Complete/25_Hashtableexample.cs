using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Complete
{
    class Hashtableexample
    {
        public static void Main()
        {
            Hashtable ingredientes = new Hashtable
            {
                { "Café au Lait", "Coffee, Milk" },
                { "Café Mocha","Coffee, Milk, Chocolate"},
                { "Capuchino","Milk, Foam"},
                { "Irish Coffee","Coffe, Wiskey, Cram, Sugar"},
                { "Machiato","Coffe, Milk, Foam"}
            };

            if(ingredientes.ContainsKey("Café Mocha"))
            {
                Console.WriteLine($"The ingresdientes of a Café Mocha are:{ingredientes["Café Mocha"]}");
            }

            Hashtable prices = new Hashtable
            {
                { "Café au Lait", 1.99M },
                { "Caffe Americano", 1.89M },
                { "Café Mocha", 2.99M },
                { "Capuchino", 2.49M },
                { "Espresso", 1.39M },
                { "Espresso Romano", 1.59M },
                { "English Tea", 1.34M },
                { "Juice", 2.23M }
            };

            //LINQ
            // from <variable names> in <data source>
            // where <selection criteria>
            // orderby <result ordering criteria>
            // select <variable names>
            var bargains =
                from string drink in prices.Keys
                where ((Decimal)prices[drink] < 2.00M)
                orderby prices[drink] ascending
                select drink;
            //Dsplay the results
            foreach (string barga in bargains)
            {
                Console.WriteLine(barga);
            }
            Console.ReadLine();

            // Query the hastable to order drinks by cost.
            // Return First, last, max and min
            var drinks =
                from string drink in prices.Keys
                orderby prices.Keys ascending
                select drink;
            Console.WriteLine($"The cheapest drink is {drinks.FirstOrDefault()}");
            Console.WriteLine($"The most expansive drink is {drinks.Last()}");
            Console.WriteLine($"The maximun is {drinks.Max()}");
            Console.WriteLine($"The minimun in {drinks.Min()}");
            Console.ReadLine();
        }

    }
}
