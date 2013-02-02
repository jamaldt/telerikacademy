using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_replaces_all_occurrences_of_one_str_with_another
{
    //Write a program that replaces all occurrences of the substring "start" with
    //the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter(@"..\..\output.txt");
            StreamReader reader = new StreamReader(@"..\..\input.txt");
  
            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    string str;
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if ( line != null)
                            line = line.Replace("start", "finish");
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
