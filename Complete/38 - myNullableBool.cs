using System;using System.Collections.Generic;using System.Linq;
namespace _01_Complete{
    class myNullableBool{
        public static void Main() {
            Console.WriteLine("Testing Dictionary Class");
            bool? resultado = FindInList("Finance", 0);
            FindInIt(resultado);
            resultado = FindInList("Accounting", 1); FindInIt(resultado);
            resultado = FindInList("Accounting", 2); FindInIt(resultado);
            Console.ReadLine();
        }
        private static void FindInIt(bool? resultado){
            switch (resultado) {
                case null:Console.WriteLine("null");break;
                case true:Console.WriteLine("true");break;
                case false:Console.WriteLine("false");break;
                default:Console.WriteLine("indeterminado");break;
            }
        }
        private static Dictionary<string, int> CreateTestData(){
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"Accounting", 1},
                {"Marketing",2},
                {"Operation",3}
            };
            return dict;
        }
        private static bool? FindInList(string searchTerm, int value)
        {
            Dictionary<string, int> data = CreateTestData();
            return data.Contains(new KeyValuePair<string, int>(searchTerm, value));
        }
    }
}
