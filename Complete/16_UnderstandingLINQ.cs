﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Complete
{
    class UnderstandingLINQ
    {
        static void Main(string[] args)
        {
            Car car1 = new Car()
            {
                VIN = "A1",
                Make = "BMW",
                Model = "550i",
                StickerPrice = 55000,
                Year = 2009
            };
            List<Car> myCars = new List<Car>() {
                car1,
                new Car() { VIN="B2", Make="Toyota", Model="4Runner",
                    StickerPrice =35000, Year=2010},
                new Car() { VIN="C3", Make="BMW", Model = "745li",
                    StickerPrice =75000, Year=2008},
                new Car() { VIN="D4", Make="Ford", Model="Escape",
                    StickerPrice =25000, Year=2008},
                new Car() { VIN="E5", Make="BMW", Model="55i",
                    StickerPrice =57000, Year=2010}
            };

            // LINQ query
            var bmws = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2010
                       select car;
            var orderedCars = from car in myCars
                              orderby car.Year descending
                              select car;
            // LINQ method
            bmws = myCars.Where(
                p => p.Make == "BMW" && p.Year == 2010);
            orderedCars = myCars.OrderByDescending(p => p.Year);
            var firstBMW = myCars.OrderByDescending(
                p => p.Year).First(p => p.Make == "BMW");
            Console.WriteLine(firstBMW.VIN);
            Console.WriteLine(myCars.TrueForAll(
                p => p.Year > 2007));
            myCars.ForEach(p => p.StickerPrice -= 3000);
            myCars.ForEach(p => Console.WriteLine("{0} {1:C}",
                p.VIN, p.StickerPrice));
            Console.WriteLine(myCars.Exists(
                p => p.Model == "745li"));
            Console.WriteLine(myCars.Sum(p => p.StickerPrice));
            foreach (var car in orderedCars)
            {
                Console.WriteLine("{0} {1}", car.Year,
                    car.Model, car.VIN);
            }
            orderedCars = myCars.OrderByDescending(p => p.Year);
            Console.WriteLine(orderedCars.GetType());
            bmws = myCars.Where(
                p => p.Make == "BMW" && p.Year == 2010);
            Console.WriteLine(bmws.GetType());
            var newCars = from car in myCars
                          where car.Make == "BMW"
                          && car.Year == 2010
                          select new { car.Make, car.Model };
            Console.WriteLine(newCars.GetType());
            Console.ReadLine();
        }
    }
    class pointExam
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
            List<Category> categories = new List<Category>()
        {
            new Category() {ID = 1, Name = "Food"},
            new Category() {ID = 2, Name = "Clothing"}
        };
            List<Product> products = new List<Product>()
        {
            new Product() {Name="Strawberry", CategoryID = 1},
            new Product() {Name="Banana", CategoryID = 1},
            new Product() {Name="Pants", CategoryID = 2}
        };
            var productsWithCategories =
                from product in products
                join category in categories
                on product.CategoryID equals category.ID
            select new { Name = product.Name, Category = category.Name };

        }

    }
    public class Product
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}