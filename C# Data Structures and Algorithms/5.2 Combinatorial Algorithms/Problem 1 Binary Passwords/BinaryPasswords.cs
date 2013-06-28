using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_Binary_Passwords
{
    class BinaryPasswords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count = 0;
            foreach (var item in input)
            {
                if (item == '*')
                {
                    count++;
                }
            }

            long result = 1L << count;
            Console.WriteLine(result);
        }
    }
}
