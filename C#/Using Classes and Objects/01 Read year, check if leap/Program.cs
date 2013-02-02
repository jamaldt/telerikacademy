using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Read_year__check_if_leap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("The year {0} is Leap!", year);
            }
            else
            {
                Console.WriteLine("The year {0} is NOT Leap!", year);
            }
        }
    }
}
