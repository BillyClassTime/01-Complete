using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete
{
    class SpanDemo
    {
        public static void Main()
        {
            int[] array = new int[10];
            Span<int> span = array.AsSpan();
            Span<int> slice = span.Slice(3, 5);
            for (int i = 0; i < 10; i++) array[i] = i;
            foreach (var v in slice)
            {
                Console.WriteLine(v.ToString());
            }
            slice[2] = 100;
            Console.WriteLine("======== Original array ====");
            foreach (var v in array)
            {
                Console.WriteLine(v.ToString());
            
            }
            Console.WriteLine(@"Path:C:\Windows\Microsoft.NET\Framework\v4.0.30319");
            Console.Write(typeof(string).Assembly.ImageRuntimeVersion);
            Console.ReadLine();
        }
    }
}
