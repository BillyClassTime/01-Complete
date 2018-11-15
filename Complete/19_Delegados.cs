using System;
namespace _01_Complete
{
    class Ejemplo_Delegados
    {
        public delegate string delegado(string mensaje);
        public delegate double delegado1(int a, int b);
        public static void Main()
        {
            Ejemplo_Delegados o_delegado = new Ejemplo_Delegados();
            delegado del = o_delegado.Mensaje_Delegado;
            string mensajeResultado=string.Format($"ResultadoFinal-{del("llamada")}");
            Console.WriteLine($"{mensajeResultado}-press... cualquier tecla...");
            Console.ReadLine();
            Cafetera cafetera = new Cafetera();
            delegado1 del1 = cafetera.TiempoCopcion;
            double tiempoCopción = del1(5 , 4);
            Console.WriteLine($"{tiempoCopción}-es el tiempo de copción");
            Console.ReadLine();
        }
        private string Mensaje_Delegado(string mensaje)
        {
            mensaje = String.Format($"{mensaje}:desde el delegado");
            Console.WriteLine(mensaje);
            return mensaje;
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
