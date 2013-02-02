using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lexicographically_compare_two_arrays
{
    //Write a program that compares two char arrays lexicographically (letter by letter).
    class Program
    {
        static void Main(string[] args)
        {
            char[][] arrays = new char[2][];

            for (int i = 0; i < 2; i++)
            {
                string input = Console.ReadLine();                
                arrays[i] = new char[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    arrays[i][j] = input[j];
                }
            }

            int minLength;
            if (arrays[0].Length < arrays[1].Length)
            {
                minLength = arrays[0].Length;
            }
            else
            {
                minLength = arrays[1].Length;
            }

            for (int i = 0; i < minLength; i++)
            {
                if (arrays[0][i] == arrays[1][i])
                    continue;



                if (arrays[0][i] < arrays[1][i])
                {
                    Console.WriteLine("First array is first :)");
                    return;
                }
                else
                {
                    Console.WriteLine("Second array is first :)");
                    return;
                }
            }
            if ((arrays[0].Length == minLength) && (arrays[1].Length == minLength))
            {
                Console.WriteLine("equal");
            }
            else if (arrays[0].Length == minLength)
            {
                Console.WriteLine("First is first");
            }
            else
            {
                Console.WriteLine("Second is first");
            }
        }
    }
}
