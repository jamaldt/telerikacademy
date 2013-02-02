using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Last_number_as_word
{
    //Write a method that returns the last digit of given integer as an English word.
    //Examples: 512  "two", 1024  "four", 12309  "nine".
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitToWord(n));
        }

        static string LastDigitToWord(int n)
        {
            int x = n % 10;
            switch (x)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "error";
            }
        }
    }
}
