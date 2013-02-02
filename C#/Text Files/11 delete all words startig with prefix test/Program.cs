using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11_delete_all_words_startig_with_prefix_test
{
    //Write a program that deletes from a text file all words that 
    //start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.
    class Program
    {
        static void Main(string[] args)
        {
            List<string> newFile = new List<string>();
            ReadFile(newFile, @"..\..\input.txt");
            WriteFile(newFile, @"..\..\output.txt");
        }

        private static void WriteFile(List<string> newFile, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            using (writer)
            {
                for (int i = 0; i < newFile.Count; i++)
                {
                    writer.WriteLine(newFile[i]);
                }
            }
        }

        private static void ReadFile(List<string> newFile, string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string pattern = @"\stest\w+";
            Regex rgx = new Regex(pattern);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = rgx.Replace(line," ");
                    newFile.Add(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
