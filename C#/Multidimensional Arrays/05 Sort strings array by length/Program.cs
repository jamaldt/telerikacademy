using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Sort_strings_array_by_length
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = new string[] { "12345", "123", "123456789", "1234", "123456789" };

            QuickSortRecursion(strings, 0, strings.Length - 1);

            Console.WriteLine("sorted by length:");
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }

        }

        static void QuickSortRecursion(string[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(arr, p, r);
                QuickSortRecursion(arr, p, q - 1);
                QuickSortRecursion(arr, q + 1, r);
            }
        }

        private static int Partition(string[] arr, int p, int r)
        {
            int pivot = arr[r].Length;
            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                if (arr[j].Length <= pivot)
                {
                    i = i + 1;
                    Exchange(arr, i, j);
                }
            }

            Exchange(arr, i + 1, r);
            return i + 1;
        }

        private static void Exchange(string[] arr, int i, int j)
        {
            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
