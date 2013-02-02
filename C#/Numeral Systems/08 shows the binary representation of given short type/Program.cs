using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_shows_the_binary_representation_of_given_short_type
{
    //Write a program that shows the binary representation of 
    //given 16-bit signed integer number (the C# type short).
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter number [{0}..{1}]: ", short.MinValue, short.MaxValue);
            short n = short.Parse(Console.ReadLine());

            StringBuilder num = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                num.Append(n >> i & 1);
            }

            for (int i = num.Length - 1; i >= 0; i--)
            {
                Console.Write(num[i]);
            }
            Console.WriteLine();
        }
    }
}
