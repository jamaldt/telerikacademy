using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3_Dividers
{
    class Dividers
    {
        private static string[] digits;
        private static bool[] used;
        static int[] arr;
        private static int n; // броя елементи
        private static int k; // количество елементи от които да правим вариациите <= n

        private static int minDividersCount = int.MaxValue;
        private static List<int> minDividersNumbers = new List<int>();

        static void Main(string[] args)
        {
            ReadInput();
            GenerateVariationsNoRepetitions(0);

            int minNumber = int.MaxValue;
            foreach (var num in minDividersNumbers)
            {
                if (minNumber > num)
                {
                    minNumber = num;
                }
            }

            Console.WriteLine(minNumber);
        }

        private static void ReadInput()
        {
            n = int.Parse(Console.ReadLine());
            k = n;
            digits = new string[n];
            used = new bool[n];
            arr = new int[k];
            for (int i = 0; i < n; i++)
            {
                digits[i] = Console.ReadLine();
            }
        }

        private static int CountDividers(int number)
        {
            int count = 1;
            int length = number / 2 + 1;
            for (int i = 1; i < length; i++)
            {
                if (number % i == 0)
                {
                    count += 1;
                }
            }

            return count;
        }

        static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariation();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void PrintVariation()
        {
            //Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(digits[arr[i]] + " ");
            //}
            //Console.WriteLine(")");

            int index = 0;
            while (digits[arr[index]].Equals("0"))
            {
                index++;
            }

            string number = "";
            for (int i = index; i < arr.Length; i++)
            {
                number += digits[arr[i]];
            }

            int num = int.Parse(number);
            int dividersCount = CountDividers(num);

            if (minDividersCount == dividersCount)
            {
                minDividersNumbers.Add(num);
            }
            else if (minDividersCount > dividersCount)
            {
                minDividersNumbers.Clear();
                minDividersNumbers.Add(num);
                minDividersCount = dividersCount;
            }
        }
    }
}
