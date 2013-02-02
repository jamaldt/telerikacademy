using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Filled_end_of_string_with_stars
{
    //Write a program that reads from the console a string of maximum 20 characters. 
    //If the length of the string is less than 20, the rest of the characters should 
    //be filled with '*'. Print the result string into the console.
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.Write(str);
            for (int i = 0; i < 20 - str.Length; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            str = str.PadRight(20, '*');
            Console.WriteLine(str);

        }
    }
}
