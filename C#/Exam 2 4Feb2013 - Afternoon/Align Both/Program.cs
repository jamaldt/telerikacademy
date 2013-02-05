using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Align_Both
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            string line;
            List<string> words = new List<string>();
            StringBuilder text = new StringBuilder();
            string[] tmp;

            for (int i = 0; i < lines; i++)
            {
                line = Console.ReadLine();
                line = Regex.Replace(line, @"\s+", " ");
                tmp = line.Split();
                foreach (var item in tmp)
                {
                    if(!String.IsNullOrWhiteSpace(item))
                        words.Add(item);
                }                
            }

            
            List<string> newLine = new List<string>();
            for (int i = 0; i < words.Count; i++)
            {
                text.Append(words[i]);
                if (text.Length == w)
                {
                    Console.WriteLine(text);
                    text.Clear();
                    continue;
                }
                else if (text.Length > w)
                {
                    text.Remove((text.Length - words[i].Length), words[i].Length);
                    i--;
                    JustifyString(text, w);
                    text.Clear();
                    continue;
                }
                else if (text.Length < w && i == words.Count - 1)
                {
                    JustifyString(text, w);
                    text.Clear();
                    continue;
                }

                text.Append(" ");
                if (text.Length == w)
                {
                    JustifyString(text, w);
                    text.Clear();
                }
            }




        }

        private static void JustifyString(StringBuilder text, int w)
        {
            //Console.WriteLine("DEBUG:" + text);
            string[] word = (text.ToString()).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (word.Length == 1)
            {
                Console.WriteLine(word[0]);
                return;
            }

            int lineLength = 0;
            StringBuilder[] words = new StringBuilder[word.Length];
            for (int i = 0; i < word.Length - 1; i++)
            {
                words[i] = new StringBuilder();
                words[i].Append(word[i]);
                words[i].Append(' ');
                lineLength += words[i].Length;
            }
            words[words.Length - 1] = new StringBuilder();
            words[words.Length -1].Append(word[word.Length - 1]); // append last word
            lineLength += words[words.Length - 1].Length;

            int position = 0;
            while (lineLength != w)
            {
                position %= words.Length - 1;
                words[position].Append(' ');
                position++;
                lineLength++;
            }

            text.Clear();
            for (int i = 0; i < words.Length; i++)
            {
                text.Append(words[i]);
            }

            Console.WriteLine(text);
        }
    }
}
