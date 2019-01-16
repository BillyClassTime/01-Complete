using System;
namespace _01_Complete      {
    class myHeritage        {
        static void Main()  {
            Worker w = new Worker(); w.Run();
            Console.ReadLine();
        }
    }
    public class ItemBase   { }
    public class Widget : ItemBase { }
    class Worker            { 
        void DoWork(object obj)         {
            Console.WriteLine("In DoWork(object)");
        }
        void DoWork(Widget widget)      {
            Console.WriteLine("In DoWork(Widget)");
        }
        void DoWork(ItemBase itembase)  {
            Console.WriteLine("In DoWork(itemBase)");
        }
        public void Run()               {
            object o = new Widget();
            //DoWork(0);                //Original and remplaced line for followings:
            DoWork((Widget)o);          //In DoWork(widget)
            //DoWork(o as Widget); 		//In DoWork(widget)
            //DoWork(o is Widget); 		//In DoWork(object)
            //DoWork((ItemBase)o); 		//In DoWork(itemBase)
            //DoWork(new Widget(o)); 	//Widget' does not contain a constructor that takes 1 arguments
        }
    }
}
