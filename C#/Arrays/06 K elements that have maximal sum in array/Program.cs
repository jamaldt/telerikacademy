using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_K_elements_that_have_maximal_sum_in_array
{
    /*
     * Write a program that reads two integer numbers N and K and an array
     * of N elements from the console. Find in the array those K elements 
     * that have maximal sum. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);
            for (int i = arr.Length-1; i >= (arr.Length - k); i--)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}


/*
9
2
12
9
7
4
1
6
5
8
12
*/