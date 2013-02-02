using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Subset_of_K_elements_equals_S_from_array
{
    // Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
    // Find in the array a subset of K elements that have sum S or indicate about its absence.
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            ArrayList list = new ArrayList();

            int sum;
            int j;
            int sequence;

            for (int i = 1; i < Math.Pow(2, arr.Length) - 1; i++)
            {
                if (CountBits(i) == k)
                {
                    sum = 0;
                    j = 0;
                    sequence = i;
                    while (sequence > 0)
                    {
                        if (sequence % 2 > 0)
                            sum += arr[j];
                        sequence /= 2;
                        j++;
                    }

                    if (sum == s)
                        list.Add(i);
                }
            }

            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    j = 0;
                    sum = (int)item;
                    while (sum > 0)
                    {
                        if (sum % 2 > 0)
                        {
                            Console.Write(arr[j] + " ");
                        }
                        j++;
                        sum /= 2;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("no such subset exist");
            }

           
        }

        private static int CountBits(int number)
        {
            int count = 0;
            while (number > 0)
            {
                if ((number & 1) > 0)
                    count++;
                number >>= 1;
            }
            return count;
        }

    }
}

/*
9
3
7
1
9
5
4
5
9
3
2
8
*/

