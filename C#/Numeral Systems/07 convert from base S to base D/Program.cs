using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_convert_from_base_S_to_base_D
{
    //Write a program to convert from any numeral system of given base s 
    //to any other numeral system of base d (2 ≤ s, d ≤  16).
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("base S: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("enter num in base S: ");
            string num = Console.ReadLine();
            Console.Write("base D to convert num in: ");
            int d = int.Parse(Console.ReadLine());

            NumeralSystemConverter number = new NumeralSystemConverter(num, s);
            Console.WriteLine(number.ConvertToBase(d));
            
        }


    }
}
