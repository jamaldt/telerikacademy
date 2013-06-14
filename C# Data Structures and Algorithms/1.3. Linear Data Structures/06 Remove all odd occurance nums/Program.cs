using System;
using System.Collections.Generic;

namespace _06_Remove_all_odd_occurance_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> expectedResult = new List<int>() {5,3,3,5};
            IDictionary<int, int> occurencies = new Dictionary<int, int>();

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
                if (item.Value % 2 != 0)
                {
                    list.RemoveAll(num => num == item.Key);
                }
            }

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
