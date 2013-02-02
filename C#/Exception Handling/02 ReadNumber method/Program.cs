using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ReadNumber_method
{
    //Write a method ReadNumber(int start, int end) that enters an integer number
    //in given range [start…end]. If an invalid number or non-number text is entered,
    //the method should throw an exception. Using this method write a program that
    //enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
    class Program
    {
        static void Main(string[] args)
        {   
            int number = 1;
            for (int i = 0; i < 11; i++)
            {
                try
                {
                    number = ReadNumber(number, 100);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("number is out of range, please try again");
                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine("format was wrong");
                    return;
                }
            }
        }

        public static int ReadNumber(int start, int end)
        {
            int n;
            try
            {
                n = int.Parse(Console.ReadLine());
                
                if (n <= start || n > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch(FormatException)
            {
                throw;
            }

            return n;
        }
    }
}
