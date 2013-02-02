using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _04_Download_file
{
    //Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
    //and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
    //all exceptions and to free any used resources in the finally block.
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "logo.jpg");
                    Console.WriteLine("file downloaded.");
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("null instead of address passed");
                }
                catch (WebException e)
                {
                    Console.WriteLine("error while downloading file");
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine("DownloadFile() cann't be called");
                }
            }
        }
    }
}
