using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Frames
{
  
    private static int[] frames;
    private static bool[] used;
    static int[] arr;
    private static int n; // броя елементи
    private static int k; // количество елементи от които да правим вариациите <= n

    private static HashSet<string> uniqueFrames = new HashSet<string>();
    private static StringBuilder sb = new StringBuilder();

    static void Main(string[] args)
    {
        ReadInput();
        GenerateVariationsNoRepetitions(0);

        for (int i = 0; i < Frames.n; i++)
        {
            int original = frames[i];
            int reverse = 10 * (original % 10) + original / 10;

            for (int l = 0; l < n; i++)
            {
                int original1 = frames[l];
                int reverse1 = 10 * (original1 % 10) + original1 / 10;

                for (int k = 0; k < n; k++)
                {
                    int original2 = frames[k];
                    int reverse2 = 10 * (original2 % 10) + original2 / 10;
                    GenerateVariationsNoRepetitions(0);
                    frames[k] = original2;
                }
                
                frames[l] = original1;
            }

            frames[i] = original; 
        }

        Console.WriteLine(uniqueFrames.Count);

        SortedSet<string> sortedFrames = new SortedSet<string>();

        foreach (var item in uniqueFrames)
        {
            sortedFrames.Add(item);
        }

        foreach (var item in sortedFrames)
        {
            Console.WriteLine(item);
        }
    }

    private static void ReadInput()
    {
        int n = int.Parse(Console.ReadLine());
        Frames.k = n;
        Frames.n = n;
        Frames.arr = new int[n];
        Frames.frames = new int[n];
        Frames.used = new bool[n];
        string[] nums = new string[2];
        int first;
        int second;

        for (int i = 0; i < n; i++)
        {
            nums = Console.ReadLine().Split(' ');
            first = int.Parse(nums[0]);
            second = int.Parse(nums[1]);
            frames[i] = 10 * first + second;
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
        int num;
        for (int i = 0; i < arr.Length; i++)
        {
            num = frames[arr[i]];
            sb.Append("(");
            sb.Append((num / 10).ToString());
            sb.Append(", ");
            sb.Append((num % 10).ToString());
            sb.Append(") | ");
        }
        sb.Length -= 3;
        uniqueFrames.Add(sb.ToString());
        sb.Clear();
    }
}