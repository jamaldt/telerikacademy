using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BinSearch___K_from_sorted_array
{
    //Write a program, that reads from the console an array of N integers and an integer K, 
    //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

    /* TEST DATA
3 5 4 2 8 7 0 3 1 5 3 9
6
     */
     
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            string[] input = str.Split(' ');
            int[] arr = new int[input.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");                    
            }
            Console.WriteLine();


            int index = Array.BinarySearch(arr, k);
            ShowWhere(arr, index);
            Console.WriteLine();



        }

        private static void ShowWhere<T>(T[] array, int index)
        {
            if (index < 0)
            {
                // If the index is negative, it represents the bitwise 
                // complement of the next larger element in the array. 
                //
                index = ~index;


                if (index == 0)
                    Console.Write("no such element in array");
                else
                    Console.Write("{0}", array[index - 1]);
                
            }
            else
            {
                Console.WriteLine("Found at index {0}.", index);
            }
        }
    }
}
