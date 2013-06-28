using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

class Program
{
    static void main(string[] args)
    {
        OrderedMultiDictionary<int, string> tasks = new OrderedMultiDictionary<int, string>(true);
        StringBuilder sb = new StringBuilder();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string inputCmd = Console.ReadLine();
            if (inputCmd.StartsWith("N"))
            {
                string[] input = inputCmd.Split(new char[] { ' ' }, 3);
                string cmd = input[0].Trim();
                int complexity = int.Parse(input[1].Trim());
                string name = input[2].Trim();

                tasks.Add(complexity, name);
            }
            else
            {
                int tasksCount = tasks.Count;
                if (tasksCount == 0)
                {
                    sb.AppendLine("Rest");
                }
                else
                {
                    int key = 0;
                    foreach (var item in tasks)
                    {
                        key = item.Key;
                    }

                    string name = null;
                    foreach (var item in tasks[key])
                    {
                        name = item;
                    }

                    sb.AppendLine(name);
                    tasks.Remove(key, name);
                }
            }
        }

        Console.Write(sb.ToString());
    }
}
