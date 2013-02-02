using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_convert_hexadecimal_numbers_to_binary_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter HEX number for example 'FF'");
            string str = Console.ReadLine();
            int n = 0;

            StringBuilder num = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                n = HexLetterToInt(str[i].ToString());
                Console.WriteLine(n);
                for (int j = 0; j < 4; j++, n /= 2)
                {
                    num.Append(n % 2);                       
                }                
            }

            for (int i = num.Length - 1; i >= 0; i--)
            {
                Console.Write(num[i].ToString());
            }
            //Console.WriteLine(hex.ToString());
            Console.WriteLine();
        }

        private static int HexLetterToInt(string f)
        {
            int n = -1;
            if (f == "0")
                n = 0;
            else if (f == "1")
                n = 1;
            else if (f == "2")
                n = 2;
            else if (f == "3")
                n = 3;
            else if (f == "4")
                n = 4;
            else if (f == "5")
                n = 5;
            else if (f == "6")
                n = 6;
            else if (f == "7")
                n = 7;
            else if (f == "8")
                n = 8;
            else if (f == "9")
                n = 9;
            else if (f == "a" || f == "A")
                n = 10;
            else if (f == "b" || f == "B")
                n = 11;
            else if (f == "c" || f == "C")
                n = 12;
            else if (f == "d" || f == "D")
                n = 13;
            else if (f == "e" || f == "E")
                n = 14;
            else if (f == "f" || f == "F")
                n = 15;
            return n;
        }
    }
}
