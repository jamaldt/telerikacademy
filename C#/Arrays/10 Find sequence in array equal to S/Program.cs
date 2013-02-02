using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Find_sequence_in_array_equal_to_S
{
    //Write a program that finds in given array of integers a sequence 
    //of given sum S (if present). 
    //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	
    class Program
    {
        static void Main(string[] args)
        {

            int s = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string[] input = str.Split(' ');
            int[] arr = new int[input.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            int[] index = SubSequenceSum(s, arr);

            if (index == null)
            {
                Console.WriteLine("no such sequence");
            }
            else
            {
                Console.Write("sequence is: ");
                for (int i = index[0]; i <= index[1]; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
            }


        }

        private static int[] SubSequenceSum(int s, int[] arr)
        {
            int sum;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum > s)
                    {
                        break;
                    }
                    if (sum == s)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

    }
}
/*
11
4 3 1 4 2 5 8
*/