using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _22_Count_word_appearance_in_a_str
{
    //Write a program that reads a string from the console and lists all
    //different words in the string along with information how many times each word is found.
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.";
            Regex word = new Regex(@"\b\w+\b");
            Match match = word.Match(str);
            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (match.Success)
            {
                if(dict.ContainsKey(match.Value))
                {
                    dict[match.Value]++;
                }
                else
                {
                    dict.Add(match.Value, 1);
                }
                match = match.NextMatch();
            }

            List<string> list = dict.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                Console.WriteLine("{0}: {1}", key, dict[key]);
            }
        }
    }
}
