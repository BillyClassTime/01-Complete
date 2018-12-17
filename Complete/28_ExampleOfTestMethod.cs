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
            var customer = new Customer();
            var dob = DateTime.Today;
            dob.AddDays(7);
            dob = dob.AddDays(7);
            dob = dob.AddYears(-24);
            Console.WriteLine($"Fecha dob:{dob.ToString()}");
            customer.DateOfBirth = dob;
            var yearsActual = customer.GetAge();
            Console.WriteLine($"EdadActual:{yearsActual}");
            Console.ReadLine();
        }
    }
    public class Customer
    {
        public DateTime DateOfBirth { get; set; }
        public int GetAge()
        {
            var diference = DateTime.Now.Subtract(DateOfBirth);
            var ageInYears = (int)(diference.Days / 365.25);
            return ageInYears;
        }
    }
}
