using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AcademyTasks2
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

            if (node.Index < tasks.Length - 2)
            {
                for (int i = 1; i <= 2; i++)
                {
                    int index = node.Index + i;
                    int task = tasks[index];
                    int min = GetMin(node.Min, task);
                    int max = GetMax(node.Max, task);
                    Tree<int> leaf = node.Add(task, index);
                    leaf.Max = max;
                    leaf.Min = min;

                    bool stopSolveCondition = CheckVariety(min, max, variety);
                    if (stopSolveCondition)
                    {
                        leaf.Variety = true;
                        continue;
                    }

                    queue.Enqueue(leaf);
                }
            }
            else if (node.Index < tasks.Length - 1)
            {
                int index = node.Index + 1;
                int task = tasks[index];
                int min = GetMin(node.Min, task);
                int max = GetMax(node.Max, task);
                Tree<int> leaf = node.Add(task, index);
                leaf.Max = max;
                leaf.Min = min;

                bool stopSolveCondition = CheckVariety(min, max, variety);
                if (stopSolveCondition)
                {
                    leaf.Variety = true;
                    continue;
                }

                queue.Enqueue(leaf);
            }
        }


        int solvedTasks = 0;
        Queue<Tree<int>> currentLevel = new Queue<Tree<int>>();
        Queue<Tree<int>> nextLevel = new Queue<Tree<int>>();

        currentLevel.Enqueue(root);

        while (currentLevel.Count > 0)
        {
            var node = currentLevel.Dequeue();

            if (node.Variety)
            {
                solvedTasks += 1;
                break;
            }

            if (node.Leafs != null)
            {
                foreach (var item in node.Leafs)
                {
                    nextLevel.Enqueue(item);
                }
            }

            if (currentLevel.Count == 0)
            {
                currentLevel = nextLevel;
                solvedTasks += 1;
                nextLevel = new Queue<Tree<int>>();
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
    public bool Variety { get; set; }
    public ICollection<Tree<T>> Leafs { get; set; }

    public Tree(T value, int index)
    {
        this.Value = value;
        this.Index = index;
        this.Variety = false;
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

