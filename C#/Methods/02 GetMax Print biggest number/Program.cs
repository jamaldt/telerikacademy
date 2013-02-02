using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GetMax_Print_biggest_number
{
    //Write a method GetMax() with two parameters that returns the bigger of two integers.
    //Write a program that reads 3 integers from the console and prints the biggest of them 
    //using the method GetMax().
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            a = GetMax(a, b);
            Console.WriteLine(GetMax(a, c));
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

    }
}
