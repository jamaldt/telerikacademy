using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Delete_all_odd_lines_from_same_file
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> newFile = new List<string>();
            //read source file
            ReadFile(newFile, @"..\..\Program.cs");
            //write it to input.txt
            WriteFile(newFile, @"..\..\input.txt");
            newFile.Clear();
            //read input :)
            ReadFileSkipOddLines(newFile, @"..\..\input.txt");
            //write without oddd
            WriteFile(newFile, @"..\..\input.txt");
        }

        private static void ReadFileSkipOddLines(List<string> newFile, string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                int index = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (index % 2 == 0)
                    {
                        newFile.Add(line);
                    }
                    index++;
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
