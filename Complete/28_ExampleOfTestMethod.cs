using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class ExampleOfTestMethod
    {
        public static void Main()
        {
            //Error en la página No. 4-11
            Customer customer = new Customer();
            DateTime dob = DateTime.Today;
            dob.AddDays(7);
            dob = dob.AddDays(7);
            dob = dob.AddYears(-24);
            Console.WriteLine($"Fecha dob:{dob.ToString()}");
            customer.DateOfBirth = dob;
            int yearsActual = customer.GetAge();
            Console.WriteLine($"EdadActual:{yearsActual}");
            Console.ReadLine();
        }
    }
    public class Customer
    {
        public DateTime DateOfBirth { get; set; }
        public int GetAge()
        {
            TimeSpan diference = DateTime.Now.Subtract(DateOfBirth);
            int ageInYears = (int)(diference.Days / 365.25);
            return ageInYears;
        }
    }
}
