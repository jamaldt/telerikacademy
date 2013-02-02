using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Encode_and_decode_a_string
{
    //Write a program that encodes and decodes a string using given encryption key (cipher).
    //The key consists of a sequence of characters. The encoding/decoding is done by performing 
    //XOR (exclusive or) operation over the first letter of the string with the first of the key,
    //the second – with the second, etc. When the last key character is reached, the next is the first.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter string for encoding:");
            string str = Console.ReadLine();
            Console.WriteLine("enter cipher:");
            string cipher = Console.ReadLine();
            Console.WriteLine("Encoded string looks like this:");
            str = DecodeString(str, cipher);
            Console.WriteLine(str);

            for (int i = 0; i < str.Length; i++)
            {
                Console.Write("\\u{0:x4}",(ushort)str[i]);
            }

            Console.WriteLine("Decoded string:");
            Console.WriteLine(DecodeString(str, cipher));
        }

        private static string DecodeString(string str, string cipher)
        {
            if (cipher.Length < 1)
                return str;
            StringBuilder s = new StringBuilder(str.Length);
            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                s.Append((char)(cipher[index] ^ str[i]));
                index++;
                index %= cipher.Length;
            }
            return s.ToString();
        }        
    }
}
