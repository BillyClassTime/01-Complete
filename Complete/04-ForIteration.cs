using System;


namespace _01_Complete
{
    class ForIteration
    {
        static void Main(string[] args)
        {
            Console.Write("Choose a number between 0 to 10:");
            string y = Console.ReadLine();
            int number;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                if (Int32.TryParse(y,out number)) // Check the value entrance is
                    //a number
                {
                    if (number==i)
                        Console.WriteLine($"{number} == {i}, then was found it!");
                }
            }
            Console.ReadLine();
                
        }
    }
}
