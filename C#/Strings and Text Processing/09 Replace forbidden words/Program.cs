using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09_Replace_forbidden_words
{
    //We are given a string containing a list of forbidden words and a text containing some of these words. 
    //Write a program that replaces the forbidden words with asterisks. Example:
    // Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
    // words: PHP, CLR, Microsoft
    // expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            Regex forbiddenWords = new Regex(@"PHP|CLR|Microsoft");
            text = forbiddenWords.Replace(text, delegate(Match match)
            {
                string v = match.ToString();
                return new String('*', v.Length);
            });
            Console.WriteLine(text);

        }
    }
}
