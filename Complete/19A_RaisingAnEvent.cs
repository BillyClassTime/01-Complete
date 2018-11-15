using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Complete
{
    class RaisingAnEvent
    {
        public static void Main()
        {
            Coffee coffe = new Coffee
            {
                Bean = "Dark",
                CountryOfOrigin = "Colombia",
                Strength = 4,
                MinimunStockLevel = 200,
                CurrentStockLevel = 300
            };
            //De la siguiente forma se puede suscribir al evento pero en la definición
            //del metodo suscrito en la linea 33 no pude ser "static"
            //      RaisingAnEvent rae = new RaisingAnEvent();
            //      coffe.OutOfBeans += rae.HandlerOutOutBean;
            //De esta forma la suscripción si puede ser a un metodo "static" de la linea 33
            coffe.OutOfBeans += new Coffee.OutOfBeanHandler(HandlerOutOutBean);

            for (int i = 0; i < 201; i++)
            {
                coffe.MakeCoffe();
            }
        }
        public static void HandlerOutOutBean(Coffee cof, EventArgs e)
        {
            Console.WriteLine("No hay grano");
            Console.ReadLine();
        }
    }
    public partial class Coffee
    {
        //Declara el evento y el delegado Pag. 3.39 mistake
        public EventArgs e = null;
        public delegate void OutOfBeanHandler(Coffee coffe, EventArgs args);
        public event OutOfBeanHandler OutOfBeans;

        private int minimunStockLevel;
        private int currentStockLevel;

        public int CurrentStockLevel
        {
            get { return currentStockLevel; }
            set { currentStockLevel = value; }
        }

        public int MinimunStockLevel
        {
            get { return minimunStockLevel; }
            set { minimunStockLevel = value; }
        }


        public void MakeCoffe()
        {
            currentStockLevel--;
            Console.WriteLine($"Beberge of Coffee:{currentStockLevel} - Done");
            //if the stock of level drops below the minimum, raise the event
            if (currentStockLevel < minimunStockLevel)
            {
                // Check whether the event is null
                //Raise the event
                e = new EventArgs();
               
                OutOfBeans?.Invoke(this, e);
                //Similar of:
                //      if(OutOfBeans!=null)
                //           OutOfBeans(this,e)
            }
        }


    }
}
