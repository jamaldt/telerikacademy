using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<String> list = new GenericList<string>(10);
            for (int i = 0; i < 15; i++)
            {
                list.Add(i.ToString());
            }

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();
            list.RemoveAt(0);
            Console.WriteLine(list);
            Console.WriteLine(list.Find("14"));
            Console.WriteLine("min element " + list.Min<String>());
        }
    }
}
