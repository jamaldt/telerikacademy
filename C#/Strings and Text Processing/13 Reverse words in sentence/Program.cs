using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13_Reverse_words_in_sentence
{
    //Write a program that reverses the words in given sentence.
	//Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "C# is not C++, not PHP and, not Delphi!";
            Regex regex = new Regex(@"\?\s*|\s+|,\s*|\.\s*|!\s*");
            string[] words = regex.Split(sentence);

            Match match = regex.Match(sentence);
            int index = words.Length - 1;
            if (String.IsNullOrEmpty(words[index]))
            {
                index--;
            }
            while (match.Success)
            {
                Console.Write(words[index] + match);
                index--;
                match = match.NextMatch();
            }
            Console.WriteLine();

        }
    }
}
