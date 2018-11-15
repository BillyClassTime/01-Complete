using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class WorkingWithStrings
    {
        static void Main(string[] args)
        {
            string myString = "my \"so called\" life";
            myString = "What if I need a new \nline caracter";
            myString = "Go to you c:\\ drive";
            myString = @"Go to you c:\drive";
            myString = String.Format("{1}={1}", "first", "second");
            myString = string.Format("{0:C}", 23403.03);
            myString = string.Format("{0:N}", 123457890);
            myString = string.Format("{0:P}", .234);
            myString = string.Format("Phone Number:{0:(###) ###-####}", 
                1234567890123);
            /*string myString = "*/ //this is a test a string with extra spaces " ;
            myString = myString.Substring(6, 14);
            myString = myString.ToUpper();
            myString = myString.Replace(" ", "--");
            myString = myString.Remove(6, 14);
            myString = String.Format("Original length:{0} - lenght without spaces:{1}", myString.Length, myString.Trim().Length);
            myString = "";
            for (int i = 0; i < 100; i++)
            {
                //myString += String.Format("-- {0}", i.ToString());
                myString += "--" + i.ToString();
            }

            StringBuilder myString_SB = new StringBuilder();
            int length = 100;
            for (int i = 0; i < length; i++)
            {
                myString_SB.Append("--");
                myString_SB.Append(i.ToString());
            }

            Console.WriteLine($"{myString_SB}" );
            Console.ReadLine();
        }
    }
}
