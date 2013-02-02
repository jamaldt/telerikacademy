using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_as_07_but_replaces_only_whole_words
{
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
                    string[] str;
                    StringBuilder s = new StringBuilder();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                            break;
                        str = line.Split(' ');
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (str[i].Equals("start"))
                            {
                                str[i] = "finish";
                            }
                            s.Append(str[i]);
                            if (i < str.Length -1)
                                s.Append(' ');
                        }
                        writer.WriteLine(s);
                        s.Clear();
                    }
                }
            }
        }
    }
}
