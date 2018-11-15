using System;
namespace _01_Complete
{
    class CustomEvent
    {
        static void Main(string[] args)
        {
            // we will create our instance
            Shipment myItem = new Shipment();

            // we need to add the delegate event to new object Remember "ShowUserMessage
            myItem.OnShipmentMade +=
                   new Shipment.ShipmentHandler(ShowUserMessage);
            

            // we assumed that the item has been just shipped and 
            // we are assigning a tracking number to it.
            myItem.TrackingNumber = "1ZY444567";

            // The common procedure to see what is going on the 
            // console screen
            Console.Read();
        }

        static void ShowUserMessage(object a, ShipArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }

    //Creamos ShipArgs hereando de la clase EventArgs
    public class ShipArgs : EventArgs
    {
        private string message;
        public string Message
        {
            get { return message; }
        }
        private string trackinId;
        public string TrackinId
        {
            get { return trackinId; }
            set { trackinId = value; }
        }

        public ShipArgs(string message,string trackinId)
        {
            this.message = message;
            this.trackinId = trackinId;
        }
    }

    public class Shipment
    {
        private string trackingnumber;

        // The delegate procedure we are assigning to our object
        public delegate void ShipmentHandler(object myObject, ShipArgs myArgs);

        public event ShipmentHandler OnShipmentMade;

        public string TrackingNumber
        {
            set
            {
                trackingnumber = value;

                // We need to check whether a tracking number 
                // was assigned to the field.
                if (trackingnumber.Length != 0)
                {
                    ShipArgs myArgs = new ShipArgs($"Item:{trackingnumber} - has been shipped.",trackingnumber);

                    // Tracking number is available, raise the event.
                    OnShipmentMade(this, myArgs);
                }
            }
        }
        // Constructor 
        public Shipment(){}
    }
}

