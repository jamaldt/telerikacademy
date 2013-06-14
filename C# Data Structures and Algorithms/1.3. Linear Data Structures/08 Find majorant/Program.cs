// * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
// Write a program to find the majorant of given array (if exists). Example:
// {2, 2, 3, 3, 2, 3, 4, 3, 3}  3

using System;
using System.Collections.Generic;

namespace _08_Find_majorant
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            IDictionary<int, int> occurencies = new SortedDictionary<int, int>();

            foreach (var num in list)
            {
                if (!occurencies.ContainsKey(num))
                {
                    occurencies.Add(num, 0);
                }

                occurencies[num] += 1;
            }

            int maxOccurNumValue = 0;
            int maxOccurNumKey = list[0];
            foreach (var item in occurencies)
            {
                if (maxOccurNumValue < item.Value)
                {
                    maxOccurNumValue = item.Value;
                    maxOccurNumKey = item.Key;
                }
            }

            bool majorant = maxOccurNumValue >= (list.Length / 2 + 1);
            if (majorant)
            {
                Console.WriteLine("Majornat: " + maxOccurNumKey);
            }
            else
            {
                Console.WriteLine("There is no majorant");
            }
        }
    }
}
