using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Count_appearance_of_letters_in_a_str
{
    //Write a program that reads a string from the console and prints all different
    //letters in the string along with information how many times each letter is found. 
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.";
            Console.WriteLine(str);
            Console.WriteLine("\n\n");

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            // Acquire keys and sort them.
            var list = dict.Keys.ToList();
            list.Sort();

            // Loop through keys.
            foreach (var key in list)
            {
                Console.WriteLine("{0}: {1}", key, dict[key]);
            }

        }
    }
}
