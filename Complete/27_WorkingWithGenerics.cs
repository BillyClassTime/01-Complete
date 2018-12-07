﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Complete
{
    class CoffeMost:IComparable
    {
        //public int Strong { get return _strong; set _strong = value; }

        private int _strong;

        public int Strong
        {
            get { return _strong; }
            set { _strong = value; }
        }

        public CoffeMost(int strong)
        {
            _strong = strong;
        }

        public int CompareTo(object obj)
        {
            var obj2 = obj as CoffeMost;

            return Strong.CompareTo(obj2.Strong);
        }
    }
    public class MyGenericClass<T>
    {
        private T myGenericField;
        public MyGenericClass(T value)
        {
            myGenericField = value;
        }
        public T MyGenericMethod(T genericParameter)
        {
            Console.WriteLine($"Parameter type: {typeof(T).ToString()}, value: {genericParameter}");
            Console.WriteLine($"Return type: {typeof(T).ToString()}, value: {myGenericField}");
            return myGenericField;
        }
        public T MyGenericProperty { get; set; }
    }

    public class WorkingWithGenerics
    {
        public static void Main()
        {
            var listaCafe = new List<CoffeMost>
            {
                new CoffeMost(2),
                new CoffeMost(3),
                new CoffeMost(1)
            };
            listaCafe.Sort();
            foreach (CoffeMost item in listaCafe)
            {
                Console.WriteLine($"{item.Strong}");
            }
            Console.ReadLine();
            // Implementing my own generic class

            var listaInt = new MyGenericClass<int>(10);
            var intValor = listaInt.MyGenericMethod(200);

            var listaString = new MyGenericClass<string>("lista");
            var stringValor = listaString.MyGenericMethod("Amigos");

            var listaDouble = new MyGenericClass<double>(23.2F);
            var doubleValor = listaDouble.MyGenericMethod(34.3F);

            Console.ReadLine();
        }
    }
}




