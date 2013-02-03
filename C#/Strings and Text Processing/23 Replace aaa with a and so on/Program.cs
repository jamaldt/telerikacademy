using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_Replace_aaa_with_a_and_so_on
{
    //Write a program that reads a string from the console and replaces all series of
    //consecutive identical letters with a single one.
    //Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aaaaabbbbbcdddeeeedssaa";
            StringBuilder word = new StringBuilder();

            word.Append(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] != str[i])
                    word.Append(str[i]);
            }
            Console.WriteLine(word);
        }
    }
}
