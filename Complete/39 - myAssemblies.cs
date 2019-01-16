using System; using System.Linq; using System.Collections.Generic;
namespace _01_Complete     {
    class myAssemblies     {
        static void Main() {
            myAssemblies ma = new myAssemblies();
            ma.Activate();
            Console.ReadLine();
        }
        void Activate()    {
            List<Type> types = (AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && 
                t.Assembly == this.GetType().Assembly)).ToList<Type>();
            foreach (var item in types) {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
