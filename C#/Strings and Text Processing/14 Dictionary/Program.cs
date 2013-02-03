using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Dictionary
{
    //A dictionary is stored as a sequence of text lines containing words and their explanations. 
    //Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
    //.NET – platform for applications from Microsoft
    //CLR – managed execution environment for .NET
    //namespace – hierarchical organization of classes
    class Program
    {
        static void Main(string[] args)
        {
            string str = @".NET – platform for applications from Microsoft
                            CLR – managed execution environment for .NET
                            namespace – hierarchical organization of classes";

            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] line = str.Split('\n');
            string[] tmp;
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = line[i].TrimStart();
                tmp = line[i].Split(new char[]{' '}, 2);
                if(!dict.ContainsKey(tmp[0]))
                {
                    dict.Add(tmp[0], tmp[1]);                    
                }
            }

            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            if (dict.ContainsKey(word))
            {
                Console.WriteLine(dict[word]);
            }
            else
            {
                Console.WriteLine("no such word in dictionary");
            }

        }
    }
}
