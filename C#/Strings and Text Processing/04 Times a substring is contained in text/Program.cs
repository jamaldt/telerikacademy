using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Times_a_substring_is_contained_in_text
{
    //Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
    //Example: The target substring is "in". The text is as follows:
    //We are living in an yellow submarine. We don't have anything else. 
    //Inside the submarine is very tight. So we are drinking all the day. 
    //We will move out of it in 5 days.
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            int count = 0;
            string findStr = "in";
            str = str.ToLower();
            int index = str.IndexOf(findStr);

            while (index != -1)
            {
                count++;
                index = str.IndexOf(findStr, index + findStr.Length);
            }
            Console.WriteLine(count);

        }
    }
}
