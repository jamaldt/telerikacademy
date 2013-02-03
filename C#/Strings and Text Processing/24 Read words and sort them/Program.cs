using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_Read_words_and_sort_them
{
    //Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\Program.cs");
            using (reader)
            {
                string file = reader.ReadToEnd();

                string[] words = file.Split(new char[]{' ', '\n', '.',')','(',';'}, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(words);
                foreach (var word in words)
                {
                    if (String.IsNullOrEmpty(word))
                        continue;
                    Console.WriteLine(word);               
                }
                Console.WriteLine("\n\n\n\n");
                // LETS DO SOME EXTRA :)
                Dictionary<string, int> dict = new Dictionary<string, int>();
                for (int i = 0; i < words.Length; i++ )
                {
                    words[i] = words[i].TrimEnd();
                    
                    if (dict.ContainsKey(words[i]))
                    {
                        dict[words[i]]++;
                    }
                    else
                    {
                        dict.Add(words[i], 1);
                    }
                }

                /*  ONE WAY TO SORT
                dict.OrderBy(key => key.Value);
                foreach (var item in dict)
                {
                    Console.WriteLine("{0} count: {1}", item.Key, item.Value);
                }
                */
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
}
