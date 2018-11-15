using System;
using System.Collections.Generic;

namespace _01_Complete
{
    class SimpleClasses
    {
        static void Main(string[] args)
        {
            Car_SC myCar = new Car_SC();
            Car_SC myCar1 = new Car_SC();
            Car_SC myCar2 = new Car_SC();

            myCar.Color = "Red";
            myCar1.Color = "Yellow";
            myCar2.Color = "White";

            myCar.Make = "Oldsmobile";
            myCar1.Make = "Ford";
            myCar2.Make = "GMC";

            myCar.Year = 1970;
            myCar1.Year = 1995;
            myCar2.Year = 2015;

            myCar.Model = "Cutlas Supreme";
            myCar1.Model = "Mustang";
            myCar2.Model = "K Series";
            
            List<Car_SC> Cars = new List<Car_SC> { myCar,myCar1,myCar2};
            foreach (Car_SC car in Cars)
            {
                
                Console.Write($"Make:{car.Make}-Model:{car.Model}-Year:" +
                    $"{car.Year.ToString()}-" +
                    $"Color:{car.Color.ToString()}-Market Value:");
                Console.WriteLine("{0:C0}", car.DetermineMarketValue());
            }
            Console.ReadLine();

        }
    }
    // Rembermer "prop" TAB-TAB define las propiedades de la clase
    class Car_SC
    {
        public string Model{ get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public decimal DetermineMarketValue()
        {
            decimal carValue;
            if (Year > 2000)
                carValue = 10000;
            else
                carValue = 2000;
            return carValue;
        }
    }
}