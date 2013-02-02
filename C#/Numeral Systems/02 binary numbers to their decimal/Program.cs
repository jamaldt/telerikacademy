using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_binary_numbers_to_their_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter bynary number for example '10'");
            string str = Console.ReadLine();
            int num = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals('1'))
                {
                    num += (int)Math.Pow(2, str.Length - i - 1);
                }
                //Console.WriteLine(str[i]);
            }
            Console.WriteLine(num);
        }
    }
}
