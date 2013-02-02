using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_convert_decimal_numbers_to_their_binary_representation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number");
            Console.WriteLine(Convert.ToString(int.Parse(Console.ReadLine()), 2));
        }
    }
}
