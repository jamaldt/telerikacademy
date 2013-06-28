using System;
using System.Collections.Generic;

class RiskWinsQueue
{
    private static HashSet<int> forbiddenNumbers = new HashSet<int>();
    private static Queue<Combination> combinations = new Queue<Combination>();
    private static int[] array = new int[5];

    static void Main(string[] args)
    {
        int initialNumber = int.Parse(Console.ReadLine());
        int targetNumber = int.Parse(Console.ReadLine());
        int forbiddenNumbersCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < forbiddenNumbersCount; i++)
        {
            forbiddenNumbers.Add(int.Parse(Console.ReadLine()));
        }

        Combination num = new Combination(initialNumber, 0);
        combinations.Enqueue(num);

        while (combinations.Count > 0)
        {
            Combination combination = combinations.Dequeue();
            if (combination.number == targetNumber)
            {
                Console.WriteLine(combination.step.ToString());
                return;
            }


            int step = combination.step + 1;
            for (int i = 0; i < 5; i++)
            {
                int[] numArr = GetArrNum(combination.number);
                int inc = IncreaseNumber(numArr, i);
                int dec = DecreaseNumber(numArr, i);

                AddCombinationToQueue(inc, step);
                AddCombinationToQueue(dec, step);
            }
        }

        // If no combination found
        Console.WriteLine("-1");
    }

    private static int[] GetArrNum(int number)
    {
        for (int i = 4; i >= 0; i--)
        {
            array[i] = number % 10;
            number /= 10;
        }

        return RiskWinsQueue.array;
    }

    private static void AddCombinationToQueue(int number, int step)
    {
        if (!forbiddenNumbers.Contains(number))
        {
            forbiddenNumbers.Add(number);
            Combination comb = new Combination(number, step);
            combinations.Enqueue(comb);
        }
    }

    private static int IncreaseNumber(int[] number, int index)
    {
        int oldValue = array[index];
        if (oldValue == 9)
        {
            array[index] = 0;
        }
        else
        {
            array[index] += 1;
        }

        int result = GetNumFromArray(array);
        array[index] = oldValue;
        return result;
    }

    private static int GetNumFromArray(int[] array)
    {
        return array[0] * 10000 + array[1] * 1000 + array[2] * 100 + array[3] * 10 + array[4];
    }

    private static int DecreaseNumber(int[] number, int index)
    {
        int oldValue = array[index];
        if (oldValue == 0)
        {
            array[index] = 9;
        }
        else
        {
            array[index] -= 1;
        }

        int result = GetNumFromArray(array);
        array[index] = oldValue;
        return result;
    }
}

struct Combination
{
    public int number;
    public int step;

    public Combination(int number, int step)
    {
        this.number = number;
        this.step = step;
    }
}

