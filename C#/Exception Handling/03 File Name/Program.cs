using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace _03_File_Name
{
    //Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
    //reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
    //Be sure to catch all possible exceptions and print user-friendly error messages.
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\WINDOWS\\win.ini";
            try
            {
                Console.WriteLine(ReadFile(path));
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file path contains a directory that cannot be found!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file '{0}' was not found!", path);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No file path is given!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entered file path is not correct!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The entered file path is too long - 248 characters are the maximum!");
            }
            catch (UnauthorizedAccessException uoae)
            {
                Console.WriteLine(uoae.Message);
            }
            catch (SecurityException)
            {
                Console.WriteLine("You don't have the required permission to access this file!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Invalid file path format!");
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
   

        static string ReadFile(string filePath)
        {
            string file = "";
            try
            {
                file = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                throw;
            }            
            return file;
        }
    }
}
