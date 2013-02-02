using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Sorting___selection_sort
{
    //Sorting an array means to arrange its elements in increasing order. 
    //Write a program to sort an array. Use the "selection sort" algorithm:
    //Find the smallest element, move it at the first position, 
    //find the smallest from the rest, move it at the second position, etc.
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] input = str.Split(' ');
            int[] arr = new int[input.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            int t;
            int min;

            for (int i = 0; i < arr.Length-1; i++)
            {
                min = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;
                    }                           
                }
                if (min != i)
                {
                    t = arr[i];
                    arr[i] = arr[min];
                    arr[min] = t;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}

/*
5 8 4 5 7 5 4 4 8 8 87 44 8 744 545 74 5
 * 
 **/
