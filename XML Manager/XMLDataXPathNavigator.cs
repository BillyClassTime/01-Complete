using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace XML_Manager
{
    class XMLDataXPathNavigator
    {
        static void Main()
        {
            // TODO 01: Enter command line file name
            string filename = "XmlPath.xml";
            // Uso de XmlDocument
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlElement root = doc.DocumentElement;
            Console.WriteLine("Before Navigate with Xpath");
            Console.WriteLine(doc.InnerXml);
            Console.ReadLine();

            // Uso de XPathDocument
            XPathDocument document = new XPathDocument(filename);
            XPathNavigator navigator = document.CreateNavigator();

            // TODO 02: Set the node for navegation
            XPathNodeIterator nodes = navigator.Select("/bookstore/book");
            while (nodes.MoveNext())
            {
                Console.Write(String.Format($"Nombre:{nodes.Current.Name}"));
                Console.WriteLine(String.Format($"--Valor:{nodes.Current.Value}"));
            }
            Console.ReadLine();

            // TODO 03: Find descendant order authors by last-name = Melville and Bob
            nodes = navigator.Select("descendant::book[author / last-name = 'Melville']");
            while (nodes.MoveNext())
            {
                // Clone iterator here when working with it.

                RecursiveWalk(nodes.Current.Clone());
            }
            Console.ReadLine();

        }



        static void RecursiveWalk(XPathNavigator navigator)
        {
            switch (navigator.NodeType)
            {
                case XPathNodeType.Element:
                    if (navigator.Prefix == String.Empty)
                        Console.WriteLine($"<{navigator.LocalName}>");
                    else
                        Console.Write($"<{navigator.Prefix}:{navigator.LocalName}>");
                    Console.WriteLine($"\t{navigator.NamespaceURI}");
                    break;
                case XPathNodeType.Text:
                    Console.WriteLine($"\t{navigator.Value}");
                    break;
            }

            if (navigator.MoveToFirstChild())
            {
                do
                {
                    RecursiveWalk(navigator);
                } while (navigator.MoveToNext());

                navigator.MoveToParent();
                if (navigator.NodeType == XPathNodeType.Element)
                    Console.WriteLine($"</{navigator.Name}>");
            }
            else
            {
                if (navigator.NodeType == XPathNodeType.Element)
                {
                    Console.WriteLine($"</{navigator.Name}>");
                }
            }
        }
    }
}
