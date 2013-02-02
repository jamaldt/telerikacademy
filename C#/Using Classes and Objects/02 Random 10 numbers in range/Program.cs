using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Random_10_numbers_in_range
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}", rand.Next(100, 201));
            }
        }
    }
}
