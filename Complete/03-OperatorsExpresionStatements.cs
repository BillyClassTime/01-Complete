using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class OperatorsExpresionStatements
    {
        static void Main(string[] args)
        {
            //Variable declaration
            int x, y, a, b;
            //Assignment operator
            x = 3;
            y = 2;
            a = 1;
            b = 0;
            // There are many mathematical operators ...
            // Addition operator
            x = 3 + 4;
            //Substractin operator;
            x = 4 - 3;
            //Multiplication operator;
            x = 10 * 5;
            //Division operator
            x = 10 / 5;
            //order of opertions using parenthesis
            x = (x + y) * (a + b);
            // There area many operators used to evaluate values ...
            // Greater than operators
            if (x>y)
            {
                Console.WriteLine($"{x} is greater than {y}");
            }
            // Equality operator
            if (x==y)
            {
                Console.WriteLine($"{x} is equal to {y}");
            }
            // Less than operator
            if (x<y)
            {
                Console.WriteLine($"{x} is less than {y}");
            }
            // Greater or equal to operator
            if (x >= y)
            {
                Console.WriteLine($"{x} is greater or equal to {y}");
            }
            //Less than or equal to operator
            if (x<=y)
            {
                Console.WriteLine($"{x} is less than or equal to {y}");
            }

            // There are two "conditional" operators as well that an be used to 
            //expend 
            // enhance an evalution. ..
            // ... and they can be combined together multiple times.

            // Conditional AND operator...
            if ((x>y) && (a>b))
            {
                Console.WriteLine($"({x}>{y}) && ({a}>{b})");
            }
            if ((x > y) || (a > b))
            {
                Console.WriteLine($"({x} > {y}) || ({a} > {b})");
            }

            // Also, here's the in-line conditional operator we learned about in 
            //the previos lesson..
            string message = (x == 1) ? "Car" : "Boat";
            Console.WriteLine($"The value of x is {x}, so the answer is {message}");
            Console.ReadLine();
        }
    }
}
