using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AcademyTasksFormula
{
    static int min;
    static int minIndex;
    static int max;
    static int maxIndex;
    static int variety;

    static void Main(string[] args)
    {
        string pleasantness = Console.ReadLine();
        variety = int.Parse(Console.ReadLine());

        string[] pleas = pleasantness.Split(new string[] { ", " }, StringSplitOptions.None);
        int num = int.Parse(pleas[0]);
        min = num;
        max = num;
        maxIndex = 0;
        minIndex = 0;

        for (int i = 1; i < pleas.Length; i++)
        {
            num = int.Parse(pleas[i]);
            GetMin(num, i);
            GetMax(num, i);
            if (CheckVariety())
            {
                CalcSteps();
                return;
            }
        }

        Console.WriteLine(pleas.Length);
    }

    private static void CalcSteps()
    {
        if (maxIndex < minIndex)
        {
            int temp = maxIndex;
            maxIndex = minIndex;
            minIndex = temp;
        }

        if (minIndex == 0)
        {
            int a = maxIndex / 2;
            int b = maxIndex % 2;
            Console.WriteLine(a + b + 1);
        }
        else
        {
            int cc = maxIndex - minIndex;
            int a = cc / 2;
            int b = cc % 2;
            int c = minIndex / 2;
            int d = minIndex % 2;

            //if (maxIndex % 2 == 0 && minIndex % 2 != 0)
            //{
            //    Console.WriteLine(a + b + c + d);
            //}
            //else if (maxIndex % 2 != 0 && minIndex % 2 == 0)
            //{
            //    Console.WriteLine(a + b + c + d);
            //}
            //else
            {
                Console.WriteLine(a + b + c + d + 1);
            }

        }
    }

    private static bool CheckVariety()
    {
        int m = max - min;
        if (m >= variety)
        {
            return true;
        }
        return false;
    }

    private static void GetMin(int task, int index)
    {
        if (min == task)
        {
            if (index % 2 == 0)
            {
                min = task;
                minIndex = index;
            }
        }
        else if (min > task)
        {
            min = task;
            minIndex = index;
        }
    }

    private static void GetMax(int task, int index)
    {
        if (max == task)
        {
            if (index % 2 == 0)
            {
                max = task;
                maxIndex = index;
            }
        }
        else if (max < task)
        {
            max = task;
            maxIndex = index;
        }
    }
}