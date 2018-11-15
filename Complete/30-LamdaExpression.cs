using System;
using System.Linq;
//using System.Security.Cryptography;
namespace _01_Complete
{
    class LamdaExpressiones
    {
        static void Main()
        {
            try
            {
                int[] source = new int[] { 6, 1, 9, 4, 2, 8, 7, 3, 5 };
                foreach (int i in source.Where(x => x > 5))
                {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
                //Aes kaes = new Aes();
                //kaes.GenerateKey();
            }

            catch (ArgumentNullException e)
            {

            }
            catch (Exception e)
            {

                throw;
            } 
        }
    }
}