using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Change_text_in_non_nested_tags
{
    //You are given a text. Write a program that changes the text in all 
    //regions surrounded by the tags <upcase> and </upcase> to uppercase.
    // We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
    // We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string upcaseTag = "<upcase>";
            string upcaseClosingTag = "</upcase>";

            int indexTag = 0;
            int indexCTag = 0;

            indexTag = str.IndexOf(upcaseTag);
            string tmp;
            while (indexTag != -1)
            {
                indexCTag = str.IndexOf(upcaseClosingTag, indexTag + upcaseTag.Length);
                int a = (indexTag + upcaseTag.Length);
                int b = (indexCTag - indexTag - upcaseTag.Length);
                tmp = str.Substring(a, b);
                tmp = tmp.ToUpper();
                str = str.Remove(indexTag, indexCTag - indexTag + upcaseClosingTag.Length);
                str = str.Insert(indexTag, tmp);
                indexTag = str.IndexOf(upcaseTag);
            }
            Console.WriteLine(str);
        }
    }
}
