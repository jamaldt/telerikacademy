using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AcademyTasks3
{
    static void Main(string[] args)
    {
        string pleasantness = Console.ReadLine();
        int variety = int.Parse(Console.ReadLine());

        string[] pleas = pleasantness.Split(new string[] { ", " }, StringSplitOptions.None);
        int solvedTasks = 1;
        int num = int.Parse(pleas[0]);
        int min = num;
        int max = num;
        int oldMin;
        int oldMax;

        for (int i = 1; i < pleas.Length; i++)
        {
            int nextNum = int.Parse(pleas[i]);
            oldMax = max;
            oldMin = min;
            min = GetMin(min, nextNum);
            max = GetMax(max, nextNum);
            bool stopCondition = CheckVariety(min, max, variety);

            if (stopCondition)
            {
                solvedTasks += 1;
                Console.WriteLine(solvedTasks);
                return;
            }
            else
            {
                if (i + 2 < pleas.Length)
                {
                    //max = oldMin;
                    //min = oldMin;
                    solvedTasks += 1;
                    i++;
                }
            }
        }

        Console.WriteLine(pleas.Length);
    }

    private static bool CheckVariety(int min, int max, int variety)
    {
        int m = max - min;
        if (m >= variety)
        {
            return true;
        }

        return false;
    }

    private static int GetMin(int min, int task)
    {
        int m = min;
        if (m > task)
        {
            m = task;
        }

        return m;
    }

    private static int GetMax(int max, int task)
    {
        int m = max;
        if (m < task)
        {
            m = task;
        }

        return m;
    }
}