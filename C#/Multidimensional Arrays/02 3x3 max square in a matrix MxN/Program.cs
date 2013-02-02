using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_3x3_max_square_in_a_matrix_MxN
{
    //Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
    /* TEST DATA

4
6
1 2 3 4 5 6
7 8 9 0 3 1
4 6 7 8 9 9
1 0 0 4 9 9

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string[] str = new string[m];
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');
                for (int j = 0; j < str.Length; j++)
                {
                    matrix[i, j] = int.Parse(str[j]);
                }
            }

            Print(matrix);

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            int sum;
            

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    sum = 0;
                    sum += matrix[row, col];
                    sum += matrix[row, col+1];
                    sum += matrix[row, col+2];
                    sum += matrix[row+1, col];
                    sum += matrix[row+1, col+1];
                    sum += matrix[row+1, col+2];
                    sum += matrix[row+2, col];
                    sum += matrix[row+2, col+1];
                    sum += matrix[row+2, col+2];

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
               
            }
            Console.WriteLine("max sum = " + maxSum);
            for (int row = maxRow; row < maxRow+3; row++)
            {
                for (int col = maxCol; col < maxCol+3; col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }
                Console.WriteLine();
            }


        }

        private static void Print(int[,] matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
			{
                for (int col = 0; col < matrix.GetLength(1); col++)
			    {
                    Console.Write("{0,4}", matrix[row,col]);
			    }
                Console.WriteLine();
			}
            Console.WriteLine();
        }
    }
}
