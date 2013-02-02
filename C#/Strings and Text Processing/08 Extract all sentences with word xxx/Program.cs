using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08_Extract_all_sentences_with_word_xxx
{
    //Write a program that extracts from a given text all sentences containing given word.
	//	Example: The word is "in". The text is:
    //We are living in a yellow submarine. We don't have anything else. 
    //Inside the submarine is very tight. So we are drinking all the day.
    //We will move out of it in 5 days.
    
    //  The expected result is:
    //We are living in a yellow submarine.
    //We will move out of it in 5 days.

    //Consider that the sentences are separated by "." and the words – by non-letter symbols.

    class Program
    {
        static void Main(string[] args)
        {
            string text = @"We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            Regex searchString = new Regex(@"\Win\W");

            string[] sentences = text.Split('.');
            
            foreach (var item in sentences)
            {
                if (searchString.IsMatch(item))
                {
                    Console.WriteLine(item.TrimStart() + ".");
                }
            }

        }
    }
}
