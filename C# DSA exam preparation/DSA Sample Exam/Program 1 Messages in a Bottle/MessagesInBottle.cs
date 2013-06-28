using System;
using System.Collections.Generic;

class MessagesInBottle
{
    private static IDictionary<string, string> dict;
    private static ICollection<Tree<string>> bottomNodes = new List<Tree<string>>();

    static void Main(string[] args)
    {
        string secretMsg = Console.ReadLine();
        string cipher = Console.ReadLine();

        dict = CreateDictionary(cipher);

        Tree<string> root = new Tree<string>("", secretMsg, null);
        DFS(root, secretMsg);

        SortedSet<string> output = new SortedSet<string>();
        Stack<string> word = new Stack<string>();
        foreach (var item in bottomNodes)
        {
            Tree<string> node = item;
            while (node.Parent != null)
            {
                word.Push(node.Value);
                node = node.Parent;
            }

            string str = "";
            foreach (var ch in word)
            {
                str += ch;
            }
            output.Add(str);
            word.Clear();
        }

        Console.WriteLine(output.Count);
        if (output.Count > 0)
        {
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }

    private static void DFS(Tree<string> root, string msg)
    {
        if (msg.Length < 1)
        {
            bottomNodes.Add(root);
            return;
        }

        string num = "";
        for (int i = 0; i < msg.Length; i++)
        {
            num += msg[i];
            if (dict.ContainsKey(num))
            {
                string remainingString = msg.Substring(i + 1);
                Tree<string> leaf = new Tree<string>(dict[num], remainingString, root);
                root.Add(leaf);
                DFS(leaf, remainingString);
            }
        }
    }

    private static IDictionary<string, string> CreateDictionary(string cipher)
    {
        IDictionary<string, string> dict = new Dictionary<string, string>();
        string num = "";
        string letter = cipher[0].ToString(); 
        string c;
        for (int i = 1; i < cipher.Length; i++)
        {
            c = cipher[i].ToString();
            switch (c)
            {
                case "0":
                    num += "0";
                    break;
                case "1":
                    num += "1";
                    break;
                case "2":
                    num += "2";
                    break;
                case "3":
                    num += "3";
                    break;
                case "4":
                    num += "4";
                    break;
                case "5":
                    num += "5";
                    break;
                case "6":
                    num += "6";
                    break;
                case "7":
                    num += "7";
                    break;
                case "8":
                    num += "8";
                    break;
                case "9":
                    num += "9";
                    break;
                default:
                    dict.Add(num, letter);
                    letter = c;
                    num = "";
                    break;
            }

        }
        // Let"s not foreget to add last letter
        dict.Add(num, letter);
        return dict;
    }
}

class Tree<T>
{
    private Tree<T> parent;
    private ICollection<Tree<T>> leafs;
    private T value;
    private T remainingString;

    public Tree(T value, T remainingString, Tree<T> parent)
    {
        this.leafs = null;
        this.value = value;
        this.remainingString = remainingString;
        this.parent = parent;
    }

    public void Add(T value, T remainingString, Tree<T> parent)
    {
        if (this.leafs == null)
        {
            this.leafs = new List<Tree<T>>();
        }

        Tree<T> leaf = new Tree<T>(value, remainingString, parent);
        this.leafs.Add(leaf);
    }

    public T Value { get { return this.value; } }
    public Tree<T> Parent { get { return this.parent; } }

    internal void Add(Tree<T> leaf)
    {
        if (this.leafs == null)
        {
            this.leafs = new List<Tree<T>>();
        }

        this.leafs.Add(leaf);
    }
}
    