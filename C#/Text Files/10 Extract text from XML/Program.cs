using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Extract_text_from_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\input.xml");
            using (reader)
            {
                int c = reader.Read();
                char symbol;
                StringBuilder word = new StringBuilder();
                bool endWord = false;
                bool startWord = false;
                while (c > 0)
                {
                    symbol = (char) c;
                    switch (symbol)
                    {
                        case '<':
                            endWord = true;
                            startWord = false;
                            break;
                        case '>':
                            startWord = true;
                            endWord = false;
                            break;
                    }

                    if (startWord && !endWord && symbol != '>' && symbol != ' ' && symbol != '\r' && symbol != '\n')
                    {
                        word.Append(symbol);
                    }

                    if (endWord && word.Length > 0)
                    {
                        Console.WriteLine(word);
                        word.Clear();
                        endWord = false;
                    }
                    c = reader.Read();
                }

            }
        }
    }
}
