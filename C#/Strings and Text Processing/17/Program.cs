using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    //Write a program that reads a date and time given in the format: 
    //day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
    class Program
    {
        static void Main(string[] args)
        {
            string str = "1.1.1111 23:14:54";
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "d.M.yyyy H:m:s";
            DateTime date = DateTime.ParseExact(str, format, provider);
            date = date.AddHours(6.5);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            Console.WriteLine(date +" "+ date.ToString("dddd"));

        }
    }
}
