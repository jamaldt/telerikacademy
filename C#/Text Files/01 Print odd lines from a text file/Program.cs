using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Print_odd_lines_from_a_text_file
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\text.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 > 0)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
}
