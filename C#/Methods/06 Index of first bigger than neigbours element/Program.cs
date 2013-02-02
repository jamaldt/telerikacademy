using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Index_of_first_bigger_than_neigbours_element
{
    //Write a method that returns the index of the first element in array that 
    //is bigger than its neighbors, or -1, if there’s no such element.
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 6, 3, 3, 5, 5, 7, 4, 34, 54, 34, 6, 563, 43, 4, 6 };
            Console.WriteLine(firstBiggerThanNeigbhors(arr));
        }

        static int firstBiggerThanNeigbhors(int[] arr)
        {
            int index = -1;
            for (int i = 1; i < arr.Length-1; i++)
            {
                if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
                    return i;
            }
            return index;
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
