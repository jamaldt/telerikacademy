using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Linked_List_implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
