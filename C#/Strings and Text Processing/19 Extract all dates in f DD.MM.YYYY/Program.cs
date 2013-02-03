using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _19_Extract_all_dates_in_f_DD.MM.YYYY
{
    //Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
    //Display them in the standard date format for Canada.
    class Program
    {
        static void Main(string[] args)
        {
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-CA");
            string text = @"03.02.2013asd 31.12.1111 I was born at 14.06.1980 . My sister was born at 3.7.1984. In 5/1999 I graduated my high school. 
                            The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime d;

            Regex date = new Regex(@"[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{4}"); 
            Match match = date.Match(text);
            
            while (match.Success)
            {
                d = DateTime.ParseExact(match.Value, "d.M.yyyy", provider);
                //Console.WriteLine(match.Value);
                Console.WriteLine(d);
                match = match.NextMatch();
            }



        }

    }
}
