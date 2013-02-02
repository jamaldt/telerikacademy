using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_remove_all_words_from_one_file_in_another
{
    //Write a program that removes from a text file all words listed 
    //in given another text file. Handle all possible exceptions in your methods.
    class Program
    {
        static void Main(string[] args)
        {
            List<string> newFile = new List<string>();
            //read source file
            ReadFile(newFile, @"..\..\Program.cs");
            //write it to input.txt
            WriteFile(newFile, @"..\..\input.txt");

            List<string> dictionary = new List<string>();
            ReadDictionary(dictionary);

            newFile.Clear();
            StreamReader reader = new StreamReader(@"..\..\input.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                string[] str;
                StringBuilder evaluatedLine = new StringBuilder();
                bool addWord = false;
                while (line != null)
                {
                    str = line.Split(' ');
                    for (int i = 0; i < str.Length; i++)
                    {
                        addWord = true;
                        foreach (var word in dictionary)
                        {
                            if (word.Equals(str[i]))
                            {
                                addWord = false;
                                break;
                            }
                        }
                        if (addWord)
                        {
                            evaluatedLine.Append(str[i]);
                            if (i < str.Length - 1)
                            {
                                evaluatedLine.Append(' ');
                            }
                        }

                    }

                    newFile.Add(evaluatedLine.ToString());
                    line = reader.ReadLine();
                    evaluatedLine.Clear();
                }
            }


            WriteFile(newFile, @"..\..\input.txt");

        }

        private static void ReadDictionary(List<string> dictionary)
        {
            StreamReader reader = new StreamReader(@"..\..\dictionary.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                string[] str;
                while (line != null)
                {
                    str = line.Split(' ');
                    foreach (var item in str)
                    {
                        dictionary.Add(item);
                    }
                    line = reader.ReadLine();
                }
            }
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
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    newFile.Add(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
