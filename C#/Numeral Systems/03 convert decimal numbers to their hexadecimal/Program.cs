using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07_convert_from_base_S_to_base_D;

namespace _03_convert_decimal_numbers_to_their_hexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            
            NumeralSystemConverter number = new NumeralSystemConverter(n, 10);
            Console.WriteLine(number.ConvertToBase(16));            
        }
    }
}
