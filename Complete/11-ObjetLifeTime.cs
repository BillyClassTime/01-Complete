using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class ObjectLifetime
    {
        static void Main(string[] args)
        {
            Car_OL myCar = new Car_OL();
            myCar.Make = "Oldsmobile";
            myCar.Model = "Cutlas Supreme";
            myCar.Year = 1986;
            myCar.Color = "Silver";
            Car_OL.MyMethod(); //Methodo statico que no necesita ser 
            //instanciado en un objeto para ser invocado
            myCar = new Car_OL("Oldsmobile", "Cutlas Supreme", 1986,
                "Silver");

            Car_OL myOtherCar = myCar;
 
            //Car myOtherCar = new Car("Ford", "Escape", 2005, "White");
            Console.WriteLine("{0}-{1}-{2}-{3}", myOtherCar.Make, 
                myOtherCar.Model, myOtherCar.Year, myOtherCar.Color);
            myOtherCar.Year = 1998;
            Console.WriteLine("{0}-{1}-{2}-{3}", myCar.Make, myCar.Model,
                myCar.Year, myCar.Color);
            //myOtherCar = null;
            ////  This will cause an exceptin of null object set
            //Console.WriteLine("{0}-{1}-{2}-{3}", myOtherCar.Make, 
            //myOtherCar.Model, myOtherCar.Year, myOtherCar.Color);
            Console.ReadLine();
        }
    }
    class Car_OL
    {
        public Car_OL(string model, string make, int year, string color)
        {
            Model = model;
            Make = make;
            Year = year;
            Color = color;
        }
        public Car_OL()
        {
            Make = "Nissan";
        }
        public string Model { get; set; }
        public string Make { get; set; }
        public int  Year { get; set; }
        public string Color { get; set; }
        public static void MyMethod()
        {
            Console.WriteLine("Called the static MyMethod");
            //Console.WriteLine(Car.Make); thi is illegal¡¡¡
        }
    }
}