using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Add_to_positive_BIGINT_numbers
{
    //Write a method that adds two positive integer numbers represented as
    //arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
    //Each of the numbers that will be added could have up to 10 000 digits.
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] {9, 1, 1, 1 }; // 1111
            int[] b = new int[] {1, 6, 1, 1 }; // 1111


            PrintNumber(a);
            Console.WriteLine("+");
            PrintNumber(b);
            int[] sum = Sum(a, b);
            Console.WriteLine("=");
            PrintNumber(sum);
        }

        private static int[] Sum(int[] a, int[] b)
        {   
            int smallerI;
            int biggerI;
            int[] smaller;
            int[] bigger;

            if (a.Length > b.Length)
            {
                bigger = a;
                smaller = b;
                biggerI = a.Length-1;
                smallerI = b.Length-1;
            }
            else
            {
                bigger = b;
                smaller = a;
                biggerI = b.Length-1;
                smallerI = a.Length - 1;
            }

            int tempSum;
            int reminder = 0;
            ArrayList sum = new ArrayList();
            while(smallerI >= 0)
            {
                tempSum = smaller[smallerI] + bigger[biggerI] + reminder;
                reminder = AddSum(tempSum, reminder, sum);
                smallerI--;
                biggerI--;
            }
            while (biggerI >= 0)
            {
                tempSum = bigger[biggerI] + reminder;
                reminder = AddSum(tempSum, reminder, sum);
                biggerI--;
            }
            if (reminder == 1)
            {
                sum.Add(1);
            }

            int[] returnSum = new int[sum.Count];
            int index = sum.Count - 1;
            foreach (int item in sum)
            {
                returnSum[index] = item;
                index--;
            }
            return returnSum;
            
        }

        private static int AddSum(int tempSum, int reminder, ArrayList sum)
        {
            if (tempSum > 10)
            {
                sum.Add(tempSum % 10);
                reminder = 1;
            }
            else
            {
                sum.Add(tempSum);
                reminder = 0;
            }
            return reminder;
        }

        private static void PrintNumber(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
    }
}
