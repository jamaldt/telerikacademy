using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Extract_all_palindromes
{
    //Write a program that extracts from a given text all palindromes, 
    //e.g. "ABBA", "lamal", "exe".
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abba lamal exe this text is to clumsy to have any more ABBA like polindroms";
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bool polindrome;
            foreach (var word in words)
            {
                polindrome = true;
                for (int i = 0; i < word.Length/2; i++)
                {
                    if (word[i] != word[word.Length - i -1])
                    {
                        polindrome = false;
                    }
                }
                if (polindrome)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
