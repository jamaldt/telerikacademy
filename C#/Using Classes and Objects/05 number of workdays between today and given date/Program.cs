using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_number_of_workdays_between_today_and_given_date
{
    //Write a method that calculates the number of workdays between today and given date,
    //passed as parameter. Consider that workdays are all days from Monday to Friday except
    //a fixed list of public holidays specified preliminary as array.     
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter date in dd.mm.yyyy: ");
            string[] str = Console.ReadLine().Split('.');
            int day = int.Parse(str[0]);
            int month = int.Parse(str[1]);
            int year = int.Parse(str[2]);

            DateTime today = DateTime.Today;
            DateTime lastDay = new DateTime(year, month, day);

            if (today > lastDay)
            {
                Console.WriteLine("you can't travel in the past");
                return;
            }

            DateTime[] holidays =
            {
                new DateTime(2013, 2, 1),
                new DateTime(2012, 2, 2),
                new DateTime(2012, 3, 3),
                new DateTime(2012, 4, 4),
                new DateTime(2013, 2, 18)
            };
            
            int workDayCounter = 0;
            bool isHoliday = false;
            int length = Math.Abs((lastDay - today).Days);
           
            for (int i = 0; i <= length; i++)
            {
                today = today.AddDays(1);
                if (today.DayOfWeek != DayOfWeek.Sunday && today.DayOfWeek != DayOfWeek.Saturday)
                {
                    for (int j = 0; j < holidays.Length; j++)
                    {
                        if (today == holidays[j])
                        {
                            isHoliday = true;
                            break;
                        }
                    }

                    if (!isHoliday)
                    {
                        workDayCounter++;
                    }

                    isHoliday = false;
                }
            }

            Console.WriteLine(workDayCounter);
        }
    }
}
