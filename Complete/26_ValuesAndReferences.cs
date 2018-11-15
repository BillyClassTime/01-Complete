using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: demo of Module 4, lesson1: Comparing Reference Types and Value Types
namespace _01_Complete
{
    class ValuesAndReferences
    {
        public static void Main()
        {
            MyStruct struc1 = new MyStruct();
            MyStruct struc2 = struc1;
            struc2.Content = 100;

            MyClass class1 = new MyClass();
            MyClass class2 = class1;
            class2.Contents = 100;

            Console.WriteLine($"Value types:struct1->{struc1.Content}, struct2->{struc2.Content}");
            Console.WriteLine($"Reference types:class1->{class1.Contents}, class2->{class2.Contents}");
            Console.ReadLine();
        }
    }
    struct MyStruct
    {
        public int Content;
    }
    class MyClass
    {
        public int Contents = 0;
    }
}
