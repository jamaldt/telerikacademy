﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Compare_two_text_files
{
    //Write a program that compares two text files line by line and prints the number
    //of lines that are the same and the number of lines that are different. Assume 
    //the files have equal number of lines.
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstFile = new List<string>();
            List<string> secondFile = new List<string>();
            ReadFile(firstFile, @"..\..\Program.cs");
            ReadFile(secondFile, @"..\..\inputB.txt");

            int same = 0;
            int diff = 0;

            for (int i = 0; i < firstFile.Count; i++)
            {
                if(firstFile[i].CompareTo(secondFile[i]) == 0)
                    same++;
                else
                    diff++;
            }
            Console.WriteLine("same lines: " + same);
            Console.WriteLine("diff lines: " + diff);
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
