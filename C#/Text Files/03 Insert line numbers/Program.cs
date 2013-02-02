using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Insert_line_numbers
{
    //Write a program that reads a text file and inserts line numbers in front of each of its lines. 
    //The result should be written to another text file.
    class Program
    {
        static void Main(string[] args)
        {
            List<string> newFile = new List<string>();
            ReadFile(newFile, @"..\..\Program.cs");
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
            using (reader)
            {
                string line = reader.ReadLine();
                int count = 1;
                string str;
                while (line != null)
                {
                    str = String.Format("{0,4}: {1}", count, line);
                    newFile.Add(str);
                    line = reader.ReadLine();
                    count++;
                }
            }
        }
    }
}
