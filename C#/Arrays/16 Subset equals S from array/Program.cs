using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Subset_equals_S_from_array
{
    //* We are given an array of integers and a number S. 
    //Write a program to find if there exists a subset of the elements of the array that has a sum S. 
    //Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
            int s = int.Parse(Console.ReadLine());
            ArrayList list = new ArrayList();

            int sum;
            int j;
            int sequence;

            for (int i = 1; i < Math.Pow(2, arr.Length) - 1; i++)
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

            foreach (var item in list)
            {
                j = 0;
                sum = (int) item;
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
    }
}
