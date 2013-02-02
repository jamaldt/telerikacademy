using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_binary_numbers_to_hexadecimal_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter bynary number for example '100111'");
            string str = Console.ReadLine();
            int length = 0;
            if (str.Length % 4 > 0)
            {
                length = 4 - str.Length % 4;
            }
            string[] bits = new string[(str.Length + length) / 4];
            int n = 0;

            for (int i = 0; i < 4; i++)
            {
                if (i < length)
                    bits[0] += "0";
                else
                    bits[0] += str[i - length];
            }
            length = str.Length % 4;
            for (int i = 1; i < bits.Length; i++)
            {
                for (int j = 0; j < 4; j++, length++)
                {
                    bits[i] += str[length];
                }
            }

            for (int i = 0; i < bits.Length; i++)
            {
                Console.Write(HexLetterToInt(bits[i]));
            }
            Console.WriteLine();
            
        }

        private static string HexLetterToInt(string f)
        {
            string n = "";
            if (f == "0000")
                n = "";
            else if (f == "0001")
                n = "1";
            else if (f == "0010")
                n = "2";
            else if (f == "0011")
                n = "3";
            else if (f == "0100")
                n = "4";
            else if (f == "0101")
                n = "5";
            else if (f == "0110")
                n = "6";
            else if (f == "0111")
                n = "7";
            else if (f == "1000")
                n = "8";
            else if (f == "1001")
                n = "9";
            else if (f == "1010")
                n = "A";
            else if (f == "1011")
                n = "B";
            else if (f == "1100")
                n = "C";
            else if (f == "1101")
                n = "D";
            else if (f == "1110")
                n = "E";
            else if (f == "1111")
                n = "F";
            return n;
        }
    }
}
