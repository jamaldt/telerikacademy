using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4_Colourful_Balls
{
    class ColourfulBalls
    {
        private static string[] elements;
        private static bool[] used;
        static int[] arr;
        private static int n; // броя елементи
        private static int k; // количество елементи от които да правим вариациите <= n

        private static HashSet<string> combinations = new HashSet<string>();

        static void Main(string[] args)
        {
            ReadInput();
            GenerateVariationsNoRepetitions(0);

            //foreach (var combination in combinations)
            //{
            //    Console.WriteLine(combination);
            //}

            Console.WriteLine(combinations.Count);

        }

        private static void ReadInput()
        {
            string input = Console.ReadLine();
            int length = input.Length;
            n = length;
            k = length;
            used = new bool[length];
            arr = new int[length];
            elements = new string[length];
            for (int i = 0; i < length; i++)
            {
                elements[i] = input[i].ToString();
            }
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
            StringBuilder combination = new StringBuilder(30);
            for (int i = 0; i < arr.Length; i++)
            {
                combination.Append(elements[arr[i]]);
            }

            combinations.Add(combination.ToString());
        }
    }
}
