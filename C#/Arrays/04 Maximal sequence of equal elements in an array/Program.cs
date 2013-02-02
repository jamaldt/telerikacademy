using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Maximal_sequence_of_equal_elements_in_an_array
{
    //Write a program that finds the maximal sequence of equal elements in an array.
	// 	Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} : {2, 2, 2}.
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] str = input.Split(' ');
            int[] arr = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = int.Parse(str[i]);
            }


            int count = 1;
            int index = 0;
            int maxCount = 0;
            bool equals = false;

            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    count = 1;
                    while (arr[i] == arr[i + 1])
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
                        maxCount = count;
                        index = i;
                    }
                }
            }
            Console.WriteLine("Number {0} repeated {1} times", arr[index], maxCount);
        }
    }
}
/*

2 1 1 2 3 3 2 2 2 1

 */

