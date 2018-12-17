using System;
using System.Collections;
using System.Collections.Generic;
namespace _01_Complete
{
    class WorkingWithCollections
    {
        static void Main()
        {
            var car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";
            var car3 = new Car
            {
                Make = "GMC",
                Model = "Grand Voyager",
                VIN = "C1"
            };
            var car2 = new Car
            {
                Make = "Geo",
                Model = "Prism",
                VIN = "B2"
            };
            var b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-00000-0";

            //ArrayLists are dynamically sized,
            //cool features sorting, remove items
            var myArrayList = new ArrayList
            {
                car1,
                car2,
                b1
            };
            try
            {
                foreach (Car car in myArrayList)
                {
                    Console.WriteLine(car.Make);
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"{e.Message} -no property was found");
            } 
            myArrayList.Remove(b1);
            //color antes de la invocación;
            var preColor = (int)Console.ForegroundColor;
            //color antes de la invocación;
            Console.ForegroundColor = ConsoleColor.White;
            myArrayList.Add(car3);
            foreach (Car car in myArrayList)
            {
                Console.WriteLine(car.Make);
            }
            Console.ForegroundColor = (ConsoleColor)preColor;
            //Esto puesde ser igual que las lineas después de lo comentado List<Car> myList = new List<Car>();
            //myList.Add(car1);
            //myList.Add(car2);

            //List<T> Esto es equivalente a lo anterior y mucho mas eficiente
            var myList = new List<Car>
            {
                car1,
                car2
            };
            //Esto genera un error myList.Add(b1);
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }
            //Esto es una colleccion generica especializad Dictionary<TKey, TValue>
            var myDictionary = new Dictionary<string, Car>
            {
                { car1.VIN, car1 },
                { car2.VIN, car2 }
            };
            Console.WriteLine(myDictionary["B2"].Make);
            if (myDictionary.TryGetValue("B2", out Car mdvalue))
            {
                Console.Write(mdvalue.Make);

            }
            else Console.WriteLine("Car not found");
            //string[] names = { "Bob", "Steve", "Brian", "Chuck" };
            // Object initializer
            // No need for a Constructor
            //Car 
            car1 = new Car { Make = "BMW", Model = "750li", VIN = "C3" };
            //Car 
            car2 = new Car { Make = "Toyota", Model = "4Runner", VIN = "D4" };
            // Collection initializer
            //List<Car> 
            myList = new List<Car> {
                new Car { Make = "Oldsmobile", Model = "Cutlas Supreme", VIN = "E5" },
                new Car { Make = "Nissan", Model = "Altima", VIN = "F6" }
            };
            Console.ReadLine();
        }
    }
    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Make { get; set; }
    }
}