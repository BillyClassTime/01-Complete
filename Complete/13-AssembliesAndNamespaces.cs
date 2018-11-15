using System;
using System.IO;
using System.Net;

namespace _01_Complete
{
    class AssembliesAndNamespaces
    {
        static void Main(string[] args)
        {
            string text = string.Format("{0} {1}","A simple example to write ",
                    "data into a file saved in disk");           
            System.Console.WriteLine(text);
            File.WriteAllText(
            @"C:\Exer\All\01-Complete\Complete\WriteText.txt", text);
            System.Console.ReadLine();

            WebClient client = new WebClient();
            string reply = client.DownloadString("http://msdn.microsoft.com");
            Console.WriteLine(reply);
            string path;
            path = string.Format("{0}{1}", @"C:\Exer\All\01-Complete\Complete\",
                "DownloadInformation.txt");

            File.WriteAllText(path,reply);
            Console.ReadLine();
        }
    }
}
