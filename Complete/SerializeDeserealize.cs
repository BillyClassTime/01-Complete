using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization; // Reference System.Web.Extension;
using System.Collections.Generic;

namespace _01_Complete
{
    public class Program
    {
        static void Main()
        {
            const string json = @"{""product"":""pencil"",""price"":12}";
            DeserealizedWithDataContractJSon(json);
            DeserealizedWIthJavaScript(json);
        }
        public static void DeserealizedWIthJavaScript(string json)
        {
            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<Dictionary<string, object>>(json);
            Console.WriteLine("DeserealizedWithJavaScript:");
            Console.WriteLine(json);
        }

        public static void DeserealizedWithDataContractJSon(string json)
        {
            //{"product":"pencil","price":12}
            var result = new Order();
            var serializer = new DataContractJsonSerializer(result.GetType());
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)){ Position = 0 };
            Console.WriteLine("DeserealizedWithDataContractJson:");
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray(), 0, ms.ToArray().Length));
            result = serializer.ReadObject(ms) as Order;
        }

    }
    [DataContract]
    internal class Order
    {
        [DataMember(Name = nameof(product), IsRequired = false)]
        internal string product;

        [DataMember]
        internal int price;
    }
}