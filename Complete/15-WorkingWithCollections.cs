using System;
using System.Collections;
using System.Collections.Generic;
namespace _01_Complete
{
    class WorkingWithCollections
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";
            Car car3 = new Car
            {
                Make = "GMC",
                Model = "Grand Voyager",
                VIN = "C1"
            };
            Car car2 = new Car
            {
                Make = "Geo",
                Model = "Prism",
                VIN = "B2"
            };
            Book b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-00000-0";

            //ArrayLists are dynamically sized,
            //cool features sorting, remove items
            ArrayList myArrayList = new ArrayList
            {
                car1,
                car2,
                b1
            };

            foreach (Car car in myArrayList)
            {
                Console.WriteLine(car.Make);
            }
            myArrayList.Remove(b1);
            //color antes de la invocación;
            int preColor = (int)Console.ForegroundColor;
            //color antes de la invocación;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            myArrayList.Add(car3);
            foreach (Car car in myArrayList)
            {
                Console.WriteLine(car.Make);
            }
            Console.ForegroundColor = (ConsoleColor) preColor;
            //List<Car> myList = new List<Car>();
            //myList.Add(car1);
            //myList.Add(car2);

            //List<T> Esto es equivalente a lo anteior y mucho mas eficiente
            List<Car> myList = new List<Car>
            {
                car1,
                car2
            };
            //myList.Add(b1);
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }
            // Dictionary<TKey, TValue>
            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>
            {
                { car1.VIN, car1 },
                { car2.VIN, car2 }
            };
            Console.WriteLine(myDictionary["B2"].Make);
            string[] names = { "Bob", "Steve", "Brian", "Chuck" };
            // Object initializer
            // No need for a Constructor
            //Car 
                car1 = new Car() { Make = "BMW", Model = "750li", VIN = "C3" };
            //Car 
                car2 = new Car() { Make = "Toyota", Model = "4Runner", VIN = "D4" };
            // Collection initializer
            //List<Car> 
                myList = new List<Car>() {
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
    }
}