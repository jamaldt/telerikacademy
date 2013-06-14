using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Remove_all_negative_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, -3, 4, -5 };
            RemoveNegativeNumbers(ref list);

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }

        private static void RemoveNegativeNumbers(ref List<int> list)
        {
            List<int> filteredList = new List<int>();
            foreach (var item in list)
            {
                if (item >= 0)
                {
                    filteredList.Add(item);
                }
            }

            list = filteredList;
        }
    }
}
