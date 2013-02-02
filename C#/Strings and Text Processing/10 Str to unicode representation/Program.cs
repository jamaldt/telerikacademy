using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Str_to_unicode_representation
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hi";
            StringBuilder s = new StringBuilder(str.Length);

            foreach (char c in str)
            {
                s.AppendFormat("\\u{0:X4}", (ushort)c);
            }
            Console.WriteLine(s);
        }
    }
}
