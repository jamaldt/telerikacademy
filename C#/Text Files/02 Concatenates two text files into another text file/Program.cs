using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Concatenates_two_text_files_into_another_text_file
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> newFile = new List<string>();
            ReadFile(newFile, @"..\..\inputA.txt");
            ReadFile(newFile, @"..\..\inputB.txt");
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
                while (line != null)
                {
                    newFile.Add(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
