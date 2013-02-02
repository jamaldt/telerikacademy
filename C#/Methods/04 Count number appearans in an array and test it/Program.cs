using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Count_number_appearans_in_an_array_and_test_it
{
    //Write a method that counts how many times given number appears in given array.
    //Write a test program to check if the method is working correctly.
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[]{1,4,6,3,3,5,5,7,4,34,54,34,6,563,43,4,6};
            Console.WriteLine(AppearenceCount(arr, 4));
        }

        static int AppearenceCount(int[] arr, int n)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (n == arr[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
