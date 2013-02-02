using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Nxm_string_matrix___longest_sequence
{
    //We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets
    //of several neighbor elements located on the same line, column or diagonal. Write a program 
    //that finds the longest sequence of equal strings in the matrix. 
     

    /* TEST DATA        ha ha ha             s s s 

3
4
ha fifi ho hi
fo ha hi xx
xxx ho ha xx


3
3
s qq s
pp pp s
pp qq s

        */
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string[] str = new string[m];
            string[][] matrix = new string[n][];

            for (int i = 0; i < n; i++)
            {
                str = Console.ReadLine().Split(' ');
                matrix[i] = str;                
            }

            int maxLength = int.MinValue;
            int length;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    length = checkDir(matrix, row, col);
                    if (maxLength < length)
                    {
                        maxLength = length;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("max length: " + maxLength);
            Console.WriteLine("element: " + matrix[maxRow][maxCol]);
            
        }

        private static int checkDir(string[][] matrix, int row, int col)
        {
            int length;
            int maxLength = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                length = findLength(matrix, row, col, i);
                if (maxLength < length)
                {
                    maxLength = length;
                }            
            }
            return maxLength;
        }

        private static int findLength(string[][] matrix, int row, int col, int dir)
        {
            int length = 1;
            if (dir == 0)
            {
                // move right
                for (int i = col+1; i < matrix[0].Length; i++)
                {
                    if (matrix[row][col].Equals(matrix[row][i]))
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dir == 1)
            {
                // move down
                for (int i = row+1; i < matrix.Length; i++)
                {
                    if (matrix[row][col].Equals(matrix[i][col]))
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            else if (dir == 2)
            {
                // move diagonal
                int l = matrix.Length> matrix[0].Length ? matrix[0].Length : matrix.Length;
                int _col = col;
                int _row = row;
                for (int i = 1; i < l; i++)
                {
                    _col ++;
                    _row ++;

                    if (_col >= matrix[0].Length)
                    {
                        break;
                    }
                    if (_row >= matrix.Length)
                    {
                        break;
                    }
                    

                    if (matrix[row][col].Equals(matrix[_row][_col]))
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            return length;
        }
    }
}
