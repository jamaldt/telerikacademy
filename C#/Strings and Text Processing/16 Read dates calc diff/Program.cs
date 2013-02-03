using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Read_dates_calc_diff
{
    //Write a program that reads two dates in the format: day.month.year
    //and calculates the number of days between them. Example:

    //Enter the first date: 27.02.2006
    //Enter the second date: 3.03.2004
    //Distance: 4 days
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            //DateTime startDate = DateTime.ParseExact(Console.ReadLine(),"d.mm.yyyy", provider);
            //DateTime endDate = DateTime.ParseExact(Console.ReadLine(),"d.mm.yyyy", provider);
            DateTime startDate = DateTime.ParseExact("27.02.2006", "d.MM.yyyy", provider);
            DateTime endDate = DateTime.ParseExact("3.03.2004", "d.MM.yyyy", provider);
            double days;
            if (startDate > endDate)
            {
                days = Math.Abs((startDate - endDate).TotalDays);
            }
            else
            {
                days = Math.Abs((endDate - startDate).TotalDays);
            }
            Console.WriteLine(days);

        }
    }
}
