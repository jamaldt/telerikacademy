using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_hexadecimal_numbers_to_their_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter HEX number for example 'FF'");
            string str = Console.ReadLine();
            int num = 0;
            int n = 0;


            for (int i = 0; i < str.Length; i++)
            {
                n = HexLetterToInt(str[i].ToString());
                 
                num += n*(int)Math.Pow(16, str.Length - i - 1);
                
                //Console.WriteLine(str[i]);
            }
            Console.WriteLine(num);
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
