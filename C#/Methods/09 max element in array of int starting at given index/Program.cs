using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_max_element_in_array_of_int_starting_at_given_index
{
    //Write a method that return the maximal element in a portion of array of integers starting at given index. 
    //Using it write another method that sorts an array in ascending / descending order.
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 32, 5, 3, 3, 5, 434, 6, 89564, 3235, 34 };

            //Console.WriteLine(MaxElement(arr, 7));

            bool asc = true;

            MySort(arr, asc);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        private static void MySort(int[] arr, bool asc)
        {
            int index;
            for (int i = 0; i < arr.Length; i++)
            {
                index = MaxElement(arr, i);
                if (i != index)
                {
                    Swap(arr, i, index);
                }
            }

            if (asc)
            {
                for (int i = 0; i < arr.Length / 2; i++)
                {
                    Swap(arr, i, arr.Length - 1 - i);
                }
            }
        }

        private static void Swap(int[] arr, int i, int index)
        {
            int temp = arr[i];
            arr[i] = arr[index];
            arr[index] = temp;
        }

        static int MaxElement(int[] arr, int pos)
        {
            int max = int.MinValue;
            int index = pos;
            for (int i = pos; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    index = i;
                }
            }
            //return max;
            return index;
        }
    }
}
