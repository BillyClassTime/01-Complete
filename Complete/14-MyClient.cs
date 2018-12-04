using ScrapeLibrary;    // Show how to do this project
                        // Don't forget to put "using ScreapLibrary here!!!"
using System;
                        // Remember Add New in Solution '01-Complete 
                        // Kind of project: Class Library (.Net Framework) 
                        // Type: C# A project for creating a C# class library(.dll)
namespace _01_Complete
{

    // Show all students The Reference in Solucion Explorer and deadlight teh
    //aseemblyes with referentiation in the projects.
    class MyClient
    {
        static void Main()
        {
            var myScrape = new Scrape();
            var value = myScrape.ScrapeWebpage("http://msdn.microsoft.com");
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
    // Show all students the other project instead 01-Complete: ScrapeLibrary
}