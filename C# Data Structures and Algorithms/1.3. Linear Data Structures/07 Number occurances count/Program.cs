using System;
using System.Collections.Generic;

namespace _07_Number_occurances_count
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = {3, 4, 4, 2, 3, 3, 4, 3, 2 };
            IDictionary<int, int> occurencies = new SortedDictionary<int, int>();

            foreach (var num in list)
            {
                if (!occurencies.ContainsKey(num))
                {
                    occurencies.Add(num, 0);
                }

                occurencies[num] += 1;
            }

            foreach (var item in occurencies)
            {
                Console.WriteLine("{0,4} -> {1,12}", item.Key, item.Value);
            }
        }
    }
}
