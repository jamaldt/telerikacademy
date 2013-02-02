using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Combinations_of_K_distinct_elements_from_set__1._.n_
{
    //Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
    //Example: 	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];

            Combinations(arr, n, 0, 1);

        }

        private static void Combinations(int[] arr, int n, int k, int next)
        {
            if (k == arr.Length)
            {
                Print(arr);
                return;
            }

            for (int i = next; i <= n; i++)
            {
                arr[k] = i;

                Combinations(arr, n, k + 1, i + 1);
            }
        }


        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
