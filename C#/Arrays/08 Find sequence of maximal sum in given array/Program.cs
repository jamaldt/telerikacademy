using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Find_sequence_of_maximal_sum_in_given_array
{
    // Write a program that finds the sequence of maximal sum in given array. Example:
	// {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	// Can you do it with only one loop (with single scan through the elements of the array)?
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] input = str.Split(' ');
            int[] arr = new int[input.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }


            //http://www.algorithmist.com/index.php/Kadane%27s_Algorithm
            int nMaxSum = Int32.MinValue;
            int nCurrentStartIndex = 0;
            int nStartIndex = 0;
            int nEndIndex = 0;
            int nCurrentSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                nCurrentSum = nCurrentSum + arr[i];
                if (nCurrentSum > nMaxSum)
                {
                    nMaxSum = nCurrentSum;
                    nStartIndex = nCurrentStartIndex;
                    nEndIndex = i;
                }

                if (nCurrentSum < 0)
                {
                    nCurrentSum = 0;
                    nCurrentStartIndex = i + 1;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Kadane's Algorithm");
            Console.WriteLine("sum = " + nMaxSum);
            for (int i = nStartIndex; i <= nEndIndex; i++)
            {
                Console.Write(arr[i] + " ");
            }


            Console.WriteLine();
            Console.WriteLine();
            int maxSum;
            int startIndex;
            int maxCount;
            maxSumSubArrayMySlowWay(arr, out maxSum, out startIndex, out maxCount);

            for (int i = startIndex; i < (startIndex + maxCount); i++)
            {
                Console.Write(arr[i] + " ");
            }
            
            Console.WriteLine("Max sum: " + maxSum);
            
            Console.WriteLine();
            Console.WriteLine("another sum = " + maxSumSubArray(arr));
        }


        private static void maxSumSubArrayMySlowWay(int[] arr, out int maxSum, out int startIndex, out int maxCount)
        {
            int sum = 0;
            maxSum = Int32.MinValue;
            int sequenceSum;
            startIndex = 0;
            int count = 0;
            maxCount = 0;

            for (int lengthOfSequence = 1; lengthOfSequence <= arr.Length; lengthOfSequence++)
            {
                sum += arr[lengthOfSequence - 1];
                sequenceSum = sum;
                count = lengthOfSequence;
                if (maxSum < sequenceSum)
                {
                    maxSum = sequenceSum;
                    startIndex = 0;
                    maxCount = lengthOfSequence;
                }
                for (int i = 0; i < (arr.Length - lengthOfSequence); i++)
                {
                    sequenceSum = sequenceSum - arr[i] + arr[i + lengthOfSequence];
                    if (maxSum < sequenceSum)
                    {
                        maxSum = sequenceSum;
                        startIndex = i + 1;
                        maxCount = count;
                    }
                }
            }
        }


        


        static int maxSumSubArray(int[] data)
        {
            int max = Int32.MinValue;
            int min = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0)
                {
                    data[i] += data[i - 1];
                }      
                if (data[i] - min > max)
                {
                    max = data[i] - min;
                }
                if (data[i] < min)
                {
                    min = data[i];
                }
            }
            return max;
        } 

    }
}

/*
2 3 -6 -1 2 -1 6 4 -8 8
*/