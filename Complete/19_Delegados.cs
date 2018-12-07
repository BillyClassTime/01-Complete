using System;
namespace _01_Complete
{
    class Ejemplo_Delegados
    {
       
        public static void Main()
        {
            var o_delegado = new UsoDelegados();
            UsoDelegados.delegado del = o_delegado.Mensaje_Delegado;
            var mensajeResultado=$"ResultadoFinal-{del("llamada")}";
            Console.WriteLine($"{mensajeResultado}-press... cualquier tecla...");
            Console.ReadLine();
            var cafetera = new Cafetera();
            UsoDelegados.delegado1 del1 = cafetera.TiempoCopcion;
            var tiempoCopción = del1(5 , 4);
            Console.WriteLine($"{tiempoCopción}-es el tiempo de copción");
            Console.ReadLine();
        }
        public class UsoDelegados
        {
            public delegate string delegado(string mensaje);
            public delegate double delegado1(int a, int b);
            public string Mensaje_Delegado(string mensaje)
            {
                mensaje = String.Format($"{mensaje}:desde el delegado");
                Console.WriteLine(mensaje);
                return mensaje;
            }
        }
        
    }
    class Cafetera
    {
        internal double TiempoCopcion(int inicio, int fin)
        {
            return inicio + fin;
        }

    }
}
