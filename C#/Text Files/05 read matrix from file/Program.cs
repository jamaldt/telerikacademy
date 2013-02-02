using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_read_matrix_from_file
{
    //Write a program that reads a text file containing a square matrix of numbers 
    //and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
    //The first line in the input file contains the size of matrix N. Each of the next N 
    //lines contain N numbers separated by space. The output should be a single number in
    //a separate text file. Example:
    class Program
    {
        static void Main(string[] args)
        {
            List<string> file = new List<string>();
            ReadFile(file, @"..\..\input.txt");

            int n = int.Parse(file[0]);
            int[,] arr = new int[n, n];
            string[] str;

            for (int i = 0; i < n; i++)
            {
                str = file[i + 1].Split(' ');
                for (int j = 0; j < str.Length; j++)
                {
                    arr[i, j] = int.Parse(str[j]);
                }
            }

            int maxSum = 0;
            int sum = 0;

            for (int row = 0; row < n-1; row++)
            {
                for (int col = 0; col < n-1; col++)
                {
                    sum = 0;
                    sum += arr[row,col];
                    sum += arr[row+1,col];
                    sum += arr[row,col+1];
                    sum += arr[row+1,col+1];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine(maxSum);
            file.Clear();
            file.Add(maxSum.ToString());
            WriteFile(file, @"..\..\output.txt");
        }

        private static void WriteFile(List<string> newFile, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            using (writer)
            {
                for (int i = 0; i < newFile.Count; i++)
                {
                    writer.WriteLine(newFile[i]);
                }
            }
        }

        private static void ReadFile(List<string> newFile, string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    newFile.Add(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
