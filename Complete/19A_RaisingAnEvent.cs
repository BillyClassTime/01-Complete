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
            var coffe = new Coffee
            {
                Bean = "Dark",
                CountryOfOrigin = "Colombia",
                Strength = 4,
                MinimunStockLevel = 15,
                CurrentStockLevel = 20
            };
            //De la siguiente forma se puede suscribir al evento pero en la definición
            //del metodo suscrito en la linea 33 no pude ser "static"
            //      RaisingAnEvent rae = new RaisingAnEvent();
            //      coffe.OutOfBeans += rae.HandlerOutOutBean;
            //De esta forma la suscripción si puede ser a un metodo "static" de la linea 33
            coffe.OutOfBeans += new Coffee.OutOfBeanHandler(HandlerOutOutBean);

            for (int i = 0; i < 20; i++)
            {
                coffe.MakeCoffe();
            }
        }
        public static void HandlerOutOutBean(Coffee cof, EventArgs e)
        {
            Console.WriteLine($"Bean:{cof.Bean}-Nivel de grano muy bajo - alerta - {(e!=null?"roja":"amarilla")}");
            Console.ReadLine();
        }
    }
    public partial class Coffee
    {
        //Declara el evento y el delegado Pag. 3.19 mistake
        public EventArgs e;
        public delegate void OutOfBeanHandler(Coffee coffe, EventArgs args);
        public event OutOfBeanHandler OutOfBeans;

        public int CurrentStockLevel { get; set; }

        public int MinimunStockLevel { get; set; }


        public void MakeCoffe()
        {
            CurrentStockLevel--;
            Console.WriteLine($"Beberge of Coffee:{CurrentStockLevel} - Done");
            //if the stock of level drops below the minimum, raise the event
            if (CurrentStockLevel < MinimunStockLevel)
            {
                // Check whether the event is null
                //Raise the event
                //Podría ser si se va a utilizar: OutOfBeans?Invoke(this, e); e = new EventArgs();
               
                OutOfBeans?.Invoke(this, null);
                //Similar of:
                //      if(OutOfBeans!=null)
                //           OutOfBeans(this,e)
            }
        }


    }
}
