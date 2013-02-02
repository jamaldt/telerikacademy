using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_Sort_array_by_removing_minimal_num_of_elements
{
    // Write a program that reads an array of integers and removes from it
    // a minimal number of elements in such way that the remaining array is 
    // sorted in increasing order. Print the remaining sorted array. Example:
	// {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] input = str.Split(' ');
            int[] arr = new int[input.Length];
            int[] flag = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }


            int maxIndex = 0;
            int maxFlag = 0;

            List<List<int>> sequence = new List<List<int>>();
            sequence.Add(new List<int>());

            // O(n^2)
            for (int i = 0; i < arr.Length; i++)
            {
                flag[i] = 1 + MaxLS(arr, flag, i);
                if (flag[i] > maxFlag)
                {
                    maxFlag = flag[i];
                    maxIndex = i;
                    sequence.Add(new List<int>());
                }
                if (maxFlag == flag[i])
                    sequence[flag[i]].Add(arr[i]);
            }

            /*
            for (int i = 0; i < flag.Length; i++)
            {
                Console.Write(flag[i] + " ");
            }
            Console.WriteLine();
            */
            //print
            int minElement;
            for (int i = 1; i < sequence.Count; i++)
            {
                minElement = Int32.MaxValue;
                for (int j = 0; j < sequence[i].Count; j++)
                {
                    if ( minElement > sequence[i][j])
                    {
                        minElement = sequence[i][j];
                    }
                }
                Console.Write(minElement + " ");
            }


        }

        private static int MaxLS(int[] arr, int[] flag, int i)
        {
            int value = 0;
            for (int j = 0; j < i; j++)
            {
                if (arr[j] <= arr[i])
                {
                    if (value < flag[j])
                    {
                        value = flag[j];
                    }
                }
            }
            return value;
        }
    }
}

/*
6 1 4 3 0 3 6 4 5 
*/