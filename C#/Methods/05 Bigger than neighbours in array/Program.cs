using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Bigger_than_neighbours_in_array
{
    //Write a method that checks if the element at given position in given array of 
    //integers is bigger than its two neighbors (when such exist).
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 6, 3, 3, 5, 5, 7, 4, 34, 54, 34, 6, 563, 43, 4, 6 };
            if (IsBiggerThanNeighbors(arr, 7))
                Console.WriteLine("bigger");
            else
                Console.WriteLine("not bigger");
        }

        static bool IsBiggerThanNeighbors(int[] arr, int pos)
        {
            if (pos > 0 && pos < arr.Length - 1)
            {
                if (pos > arr[pos - 1] && pos > arr[pos + 1])
                    return true;
            }
            return false;
        }
    }
}
