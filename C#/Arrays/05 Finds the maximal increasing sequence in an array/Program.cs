using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Finds_the_maximal_increasing_sequence_in_an_array
{
    //Write a program that finds the maximal increasing sequence in an array. Example: 
    // {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
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

            int index;
            int maxIndex = 0;
            int maxCount = 0;
            int count;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    count = 0;
                    index = i;
                    while (arr[i] < arr[i + 1])
                    {
                        i++;
                        count++;
                        if (i == arr.Length - 1)
                        {
                            break;
                        }
                    }
                    if (count > maxCount)
                    {
                        maxIndex = index;
                        maxCount = count;
                    }
                }
            }
            if (maxCount > 1)
            {
                for (int i = maxIndex; i <= maxIndex + maxCount; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}

/* Input test

3 2 3 4 2 2 4
4 5 7 8 7 4 5 8 6 2 4 47 1 2 3 4 5 6 7 9 7 54

 
 
 */