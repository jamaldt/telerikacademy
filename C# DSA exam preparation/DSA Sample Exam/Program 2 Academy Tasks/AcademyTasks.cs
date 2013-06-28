using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AcademyTasks
{
    static void Main(string[] args)
    {
        string pleasantness = Console.ReadLine();
        int variety = int.Parse(Console.ReadLine());

        string[] pleas = pleasantness.Split(new string[] { ", " }, StringSplitOptions.None);
        int[] tasks = new int[pleas.Length];
        for (int i = 0; i < pleas.Length; i++)
        {
            tasks[i] = int.Parse(pleas[i]);
        }

        int solvedTasks = 0;
        Tree<int> root = new Tree<int>(tasks[0], 0);
        root.Min = tasks[0];
        root.Max = tasks[0];

        //IDictionary<int, Tree<int>> calculatedRoots = new Dictionary<int, Tree<int>>();
        //calculatedRoots.Add(0, root);

        Queue<Tree<int>> queue = new Queue<Tree<int>>();
        queue.Enqueue(root);


        while (queue.Count > 0)
        {
            Tree<int> node = queue.Dequeue();
            solvedTasks += 1;

            if (node.Index < tasks.Length - 1)
            {
                for (int i = 1; i <= 2; i++)
                {
                    int index = node.Index + i;
                    int task = tasks[index];
                    int min = GetMin(node.Min, task);
                    int max = GetMax(node.Max, task);
                    bool stopSolveCondition = CheckVariety(min, max, variety);

                    if (stopSolveCondition)
                    {
                        solvedTasks += 1;
                        Console.WriteLine(solvedTasks);
                        return;
                    }

                    Tree<int> leaf = node.Add(task, index);
                    leaf.Max = max;
                    leaf.Min = min;
                    queue.Enqueue(leaf);
                }
            }
            else if (node.Index < tasks.Length)
            {
                int index = node.Index + 1;
                int task = tasks[index];
                int min = GetMin(node.Min, task);
                int max = GetMax(node.Max, task);
                bool stopSolveCondition = CheckVariety(min, max, variety);

                if (stopSolveCondition)
                {
                    solvedTasks += 1;
                    Console.WriteLine(solvedTasks);
                    return;
                }

                Tree<int> leaf = node.Add(task, index);
                leaf.Max = max;
                leaf.Min = min;
                queue.Enqueue(leaf);
            }
        }

        Console.WriteLine(solvedTasks);
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

class Tree<T>
{
    public T Value { get; set; }
    public int Index { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public ICollection<Tree<T>> Leafs { get; set; }

    public Tree(T value, int index)
    {
        this.Value = value;
        this.Index = index;
    }
   
    public Tree<T> Add(T value, int index)
    {
        if (this.Leafs == null)
        {
            this.Leafs = new List<Tree<T>>();
        }
            
        Tree<T> leaf = new Tree<T>(value, index);
        this.Leafs.Add(leaf);

        return leaf;
    }
}

