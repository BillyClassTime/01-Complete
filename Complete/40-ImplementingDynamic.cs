using System; using System.Dynamic;
namespace _01_Complete              {
    class ImplementingDynamic       {
        public static void Main()   {
            Console.WriteLine("Dynamic Message");
            //01 == var message = new Object with calling SendMessage(dynamic msg)
            //var message = new Object();
            //message.From = "Jon Morris";//object does not contain a definition for From
            //message.To = "Mary North";
            //message.Content = "Hello World";
            //==
            //02 == dynamic Calling SendMessage Object in SendMessage -> Object does not conatin
            //dynamic message = new { From = "Jon Morris", To = "Mary North", Contect = "Hello World"};
            //03 == var message calling SendMesage with ExpandoObject calling dynamic
            dynamic message = new ExpandoObject();
            message.From = "Jon Morris";//Work fine
            message.To = "Mary North";
            message.Content = "Hello World";
            SendMessage(message);
            //04 == var message calling dynamic SendMessage
            var message1 = new {From="Jon Morris", To = "Mary North", Content = "Hello World" };
            SendMessage(message1);// WorkFine the 04 option or choise
            Console.ReadLine();
        }
        static void SendMessage(dynamic msg){
            Console.WriteLine(msg.From); Console.WriteLine(msg.To);
            Console.WriteLine(msg.Content);
        }
    }
}