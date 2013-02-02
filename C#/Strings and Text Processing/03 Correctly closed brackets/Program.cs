using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Correctly_closed_brackets
{
    //Write a program to check if in a given expression the brackets are put correctly.
    //Example of correct expression: ((a+b)/5-d).
    //Example of incorrect expression: )(a+b)).
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int leftCount = 0;
            int rightCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ')')
                {
                    leftCount--;
                }
                else if (str[i] == '(')
                {
                    leftCount++;
                }
                if (leftCount < 0)
                {
                    Console.WriteLine("brackets aren't put correctly");
                    return;
                }
            }
            if (leftCount == 0)
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("not ok");
            }

        }
    }
}
