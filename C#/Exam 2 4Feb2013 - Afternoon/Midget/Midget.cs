using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Midget
{
    class Midget
    {
        static void Main(string[] args)
        {
            string inValley = Console.ReadLine();
            int m = int.Parse(Console.ReadLine());
            
            Regex split = new Regex(@", ");
            int[][] pattern = new int[m][];

            string[] tmp = split.Split(inValley);
            int[] valley = new int[tmp.Length];
            for (int i = 0; i < valley.Length; i++)
            {
                valley[i] = int.Parse(tmp[i]);
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                inValley = Console.ReadLine();
                tmp = split.Split(inValley);
                pattern[i] = new int[tmp.Length];
                for (int j = 0; j < pattern[i].Length; j++)
                {
                    pattern[i][j] = int.Parse(tmp[j]);
                }
            }
            //CheckInput(m, pattern, valley);
            BigInteger maxSum = 0;
            BigInteger sum;

            for (int i = 0; i < pattern.Length; i++)
            {
                sum = WalkPattern(valley, pattern[i]);
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            Console.WriteLine(maxSum);


        }

        private static BigInteger WalkPattern(int[] valley, int[] pattern)
        {
            BigInteger sum = valley[0];
            bool[] isVisitedPosition = new bool[valley.Length];
            int position = 0;
            isVisitedPosition[position] = true;
            int i = 0;
            //for (int i = 0; i < pattern.Length*2; i++)
            while(true)
            {
                position += pattern[i%pattern.Length];
                i++;
                if (position < 0 || position >= valley.Length)
                {
                    break;
                }
                if (isVisitedPosition[position])
                {
                    break;
                }
                sum += valley[position];
                isVisitedPosition[position] = true;
            }


            return sum;
        }

        private static void CheckInput(int m, int[][] pattern, int[] valley)
        {
            for (int i = 0; i < valley.Length; i++)
            {
                Console.Write(valley[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("M = " + m);
            for (int i = 0; i < pattern.Length; i++)
            {
                for (int j = 0; j < pattern[i].Length; j++)
                {
                    Console.Write(pattern[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
