using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 one = new BitArray64(1);
            BitArray64 two = new BitArray64(2);

            for (int i = 63; i >= 0; i--)
            {
                Console.Write(one[i]);
            }
            Console.WriteLine();
            for (int i = 63; i >= 0; i--)
            {
                Console.Write(two[i]);
            }
            Console.WriteLine();

            Console.WriteLine("\nDoes first equals second?");
            if (one.Equals(two))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            Console.WriteLine("\nHash codes:");
            Console.WriteLine("first: " + one.GetHashCode());
            Console.WriteLine("second: " + two.GetHashCode());

            Console.WriteLine("\nLets enumerate with foreach first number:");
            foreach (var bit in one)
            {
                Console.Write(bit);
            }
            

            Console.WriteLine();
        }
    }
}
