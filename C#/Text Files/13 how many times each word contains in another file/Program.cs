using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_how_many_times_each_word_contains_in_another_file
{
    //Write a program that reads a list of words from a file words.txt and 
    //finds how many times each of the words is contained in another file test.txt. 
    //The result should be written in the file result.txt and the words should be
    //sorted by the number of their occurrences in descending order. Handle all 
    //possible exceptions in your methods.
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, int> words = new Dictionary<string, int>();
                ReadWords(words, @"..\..\words.txt");
                ReadFile(words, @"..\..\Program.cs");
                WriteFile(words, @"..\..\result.txt");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can not find file.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Invalid directory in the file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Can not open the file");
            }
        }

        private static void WriteFile(Dictionary<string, int> words, string p)
        {
            StreamWriter writer = new StreamWriter(p);
            try
            {
                using (writer)
                {

                    foreach (var item in words.OrderByDescending(key => key.Value))
                    {
                        writer.WriteLine("{0} = {1}", item.Key, item.Value);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static void ReadFile(Dictionary<string, int> words, string p)
        {
            try
            {
                StreamReader reader = new StreamReader(p);
                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] str;
                    while (line != null)
                    {
                        str = line.Split(' ');
                        foreach (var word in str)
                        {
                            if (words.ContainsKey(word))
                            {
                                words[word]++;
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ReadWords(Dictionary<string, int> words, string fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    string line = reader.ReadLine();
                    string[] str;
                    while (line != null)
                    {
                        str = line.Split(' ');
                        foreach (var word in str)
                        {
                            if (!words.ContainsKey(word))
                            {
                                words.Add(word, 0);
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
