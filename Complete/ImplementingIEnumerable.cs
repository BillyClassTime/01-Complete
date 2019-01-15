using System;
using System.Collections.Generic;
using System.Collections;
namespace _01_Complete
{
    public class CustomerExtensionImplementingIEnumerable
    {
        public static void Main()
        {
            Console.WriteLine("Implementing IEnumerable class");
            var customers = new Customers
            {
                new Customer1 { Name = "Neil", Age = 45 },
                new Customer1 { Name = "Jon", Age = 43 },
                new Customer1 { Name = "Peter",Age = 98 }
            };
        }
    }
    public static class CustomerExtensions
    {
        public static void Add(this Customers cs, Customer1 c) => cs.AddCustomer(c);
    }
    public class Customer1
    {
        public string Name;
        public int Age;
    }
    public class Customers : IEnumerable<Customer1>
    {
        private List<Customer1> customers = new List<Customer1>();
        public void AddCustomer(Customer1 c)
        {
            customers.Add(c);
        }
        public IEnumerator<Customer1> GetEnumerator()
        {
            return ((IEnumerable<Customer1>)customers).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Customer1>)customers).GetEnumerator();
        }
    }
}