using System;
using System.IO;

namespace _01_Complete
{
    class HandlingExceptions
    {
        static void Main(string[] args)
        {
            try
            {
                string content = File.ReadAllText(@"C:\Exer\All\Exampl.txt");
                Console.WriteLine(content);

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine("Make sure the name of the file is named correctly: Exampl.txt");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine(@"Make sure the directory C:\Lesson22 exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Code to finalize
                // Setting objects to null
                // Closing database connections
                Console.WriteLine("Closing application now ...");
            }
            Console.ReadLine();
        }
    }
}
