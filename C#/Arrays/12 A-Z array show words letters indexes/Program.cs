using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Z_array_show_words_letters_indexes
{
    //Write a program that creates an array containing all letters from the alphabet (A-Z). 
    //Read a word from the console and print the index of each of its letters in the array.
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = new char[((int)'Z' - (int)'A') + 1];

            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)(i + (int)'A');
            }

            string word = Console.ReadLine();
            word = word.ToUpper();

            for (int i = 0; i < word.Length; i++)
            {
                Console.Write("{0}[{1}] ", letters[(int)word[i] - (int)'A'], (int)word[i] - (int)'A');
            }

        }
    }
}
