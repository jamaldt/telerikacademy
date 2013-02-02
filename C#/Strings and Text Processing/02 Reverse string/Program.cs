using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Reverse_string
{
    //Write a program that reads a string, reverses it and prints the result at the console.
    //Example: "sample"  "elpmas".
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            StringBuilder reversedStr = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                reversedStr.Append(str[str.Length - i - 1]);
            }
            Console.WriteLine(reversedStr);
        }
    }
}
