﻿// We are given the following sequence:
// S1 = N;
// S2 = S1 + 1;
// S3 = 2*S1 + 1;
// S4 = S1 + 2;
// S5 = S2 + 1;
// S6 = 2*S2 + 1;
// S7 = S2 + 2;
// ...
// Using the Queue<T> class write a program to print its first 50 members for given N.
// Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_Print_50_memebers_of_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 2;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(N);

            StringBuilder output = new StringBuilder();
            output.Append(queue.Peek());
            const string delimeter = ", ";
            output.Append(delimeter);

            int tempResult;
            for (int i = 1; i < 50; i++)
            {
                int value = queue.Dequeue();
                tempResult = value + 1;
                CalcStuff(queue, output, delimeter, tempResult);

                tempResult = 2 * value + 1;
                CalcStuff(queue, output, delimeter, tempResult);

                tempResult = value + 2;
                CalcStuff(queue, output, delimeter, tempResult);
            }

            Console.WriteLine(output);
        }

        private static void CalcStuff(Queue<int> queue, StringBuilder output, string delimeter, int tempResult)
        {
            queue.Enqueue(tempResult);
            output.Append(tempResult);
            output.Append(delimeter);
        }
    }
}
