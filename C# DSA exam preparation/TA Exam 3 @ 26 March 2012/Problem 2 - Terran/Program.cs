using System;
using System.Collections.Generic;

class Program
{
    private static IDictionary<string, int> wordsToNumbers = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        double radioRange = double.Parse(Console.ReadLine());
        int codeWordsNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < codeWordsNumber; i++)
        {
            string[] input = Console.ReadLine().Split();
            string word = input[0];
            int number = int.Parse(input[1]);
            wordsToNumbers.Add(word, number);
        }

        int numberOfBanshees = int.Parse(Console.ReadLine());
        ISet<Banshee> groupedBanshees = new HashSet<Banshee>();
        IList<Banshee> banshees = new List<Banshee>();
        IList<int> groupCount = new List<int>();

        for (int i = 0; i < numberOfBanshees; i++)
        {
            string[] input = Console.ReadLine().Split();
            int posX = decode(input[0]);
            int posY = decode(input[1]);
            Banshee banshee = new Banshee(posX, posY);
            banshees.Add(banshee);
        }


        int count = 0;
        for (int i = 0; i < banshees.Count; i++)
        {
            if (groupedBanshees.Contains(banshees[i]))
            {
                continue;
            }

            Banshee ban = banshees[i];
            groupedBanshees.Add(ban);

            Queue<Banshee> queue = new Queue<Banshee>();
            queue.Enqueue(ban);

            while (queue.Count > 0)
            {
                Banshee leaf = queue.Dequeue();

                foreach (var banshe in banshees)
                {
                    var banshee = banshe;
                    if (groupedBanshees.Contains(banshee))
                    {
                        continue;
                    }

                    if (leaf.GetDistance(ref banshee) > radioRange)
                    {
                        continue;
                    }

                    groupedBanshees.Add(banshee);
                    queue.Enqueue(banshee);
                }
            }

            count += 1;
        }

        Console.WriteLine(count);
    }

    private static int decode(string pos)
    {
        int length = pos.Length;
        int coordinate = 0;
        
        for (int i = 0; i < length; i+= 4)
        {
            string word = pos.Substring(i, 4);
            coordinate += wordsToNumbers[word];
        }

        return coordinate;
    }
}

struct Banshee
{
    int x;
    int y;

    public Banshee(int posX, int posY)
    {
        // TODO: Complete member initialization
        this.x = posX;
        this.y = posY;
    }


    public double GetDistance(ref Banshee other)
    {
        int x = this.x - other.x;
        int y = this.y - other.y;
        double distance = Math.Sqrt(x * x + y * y);
        return distance;
    }
}







