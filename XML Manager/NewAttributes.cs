using System;
using System.Xml;
using System.Xml.XPath;

namespace XML_Manager
{
    class NewAttributes
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            
            doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "</book>");
            XmlElement root = doc.DocumentElement;
            Console.WriteLine("Before insert Attribute");
            Console.WriteLine(doc.InnerXml);

            // Add a new attribute.  
            root.SetAttribute("genre", "urn:samples", "novel");

            Console.WriteLine("Display the modified XML...");
            Console.WriteLine(doc.InnerXml);
            Console.ReadLine();
        }
    }
}
