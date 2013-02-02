using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Variations_of_K_elements_from_set__1._._3_
{
    //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
    //Example:
	//N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];

            Variations(arr, n, 0);
        }
        
        static void Variations(int[] arr, int n, int k)
        {
            if (k == arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= n; i++)
			    {
                    arr[k] = i;
                    Variations(arr, n, k + 1);
    			}
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
