using System;
using System.Diagnostics;
namespace _01_Complete
{
    public class Alert
    {
        public event EventHandler<EventArgs> SendMessage;
        [Conditional("Debug")]
        public void Execute()
        {
            Trace.Write("LogData1");
            SendMessage(this, new EventArgs());
        }
    }

    public class Subscriber
    {
        Alert alert = new Alert();
        public void Subscribe()
        {
            alert.SendMessage += (sender, e) => { Console.WriteLine("First"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Second"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Third"); };
            alert.SendMessage += (sender, e) => { Console.WriteLine("Third"); };

        }
        public void Execute()
        {
            alert.Execute();
        }

        public static void Main()
        {
            Subscriber subscriber = new Subscriber();
            subscriber.Subscribe();
            subscriber.Execute();
        }
    }
}
