using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Read_2_arrays_and_compare_them
{
    //Write a program that reads two arrays from the console and compares them element by element.
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arrays = new int[2][];

            for (int i = 0; i < 2; i++)
            {
                string input = Console.ReadLine();
                string[] arr = input.Split(' ');
                arrays[i] = new int[arr.Length];
                for (int j = 0; j < arr.Length; j++)
                {
                    arrays[i][j] = int.Parse(arr[j]);
                }
            }

            if (arrays[0].Length != arrays[1].Length)
            {
                Console.WriteLine("Length of the arrays is different.");
            }
            else
            {
                for (int i = 0; i < arrays[0].Length; i++)
                {
                    if (arrays[0][i] != arrays[1][i])
                    {
                        Console.WriteLine("Arrays are different.");
                        return;
                    }
                }
                Console.WriteLine("Arrays are the same.");
            }


        }
    }
}
