using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Manager
{
    class Program
    {
        private const String filename = "items.xml";
        static void Main(string[] args)
        {
            XmlTextReader reader = null;

            try
            {
                // Load the reader with the data file and ignore   
                // all white space nodes.  
                reader = new XmlTextReader(filename);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.  
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Console.Write("<{0}>", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.Write(reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            Console.Write("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            Console.Write("<!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            Console.Write("<?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            break;
                        case XmlNodeType.DocumentType:
                            Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            Console.Write(reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            Console.Write("</{0}>", reader.Name);
                            break;
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
