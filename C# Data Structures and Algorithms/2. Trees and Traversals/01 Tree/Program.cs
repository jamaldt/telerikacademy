using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { 
                "8",
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
                "4 7"
            };

            int nodesCount = int.Parse(input[0]);
            Node<int>[] nodes = new Node<int>[nodesCount];

            for (int i = 1; i < input.Length; i++)
            {
                string[] str = input[i].Split(' ');
                int parentValue = int.Parse(str[0]);
                int childValue = int.Parse(str[1]);

                Node<int> parentNode;
                if (nodes[parentValue] == null)
                {
                    parentNode = new Node<int>(parentValue);
                    nodes[parentValue] = parentNode;
                }

                Node<int> childNode;
                if (nodes[childValue] == null)
                {
                    childNode = new Node<int>(childValue);
                    nodes[childValue] = childNode;
                }

                parentNode = nodes[parentValue];
                childNode = nodes[childValue];

                childNode.Parent = parentNode;
                parentNode.Childs.Add(childNode);
            }

            Node<int> treeRoot = null;
            foreach (var node in nodes)
            {
                if (node.Parent == null)
                {
                    treeRoot = node;
                    break;
                }
            }

            Queue<Node<int>> tree = new Queue<Node<int>>();
            tree.Enqueue(treeRoot);

            Console.WriteLine("Root: " + treeRoot.Value);

            while (tree.Count > 0)
            {
                Node<int> node = tree.Dequeue();
                if (node.Childs.Count > 0)
                {
                    Console.Write(node.Value + " -> ");
                    foreach (var n in node.Childs)
                    {
                        tree.Enqueue(n);
                        Console.Write(n.Value + " ");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("All leafs");
            tree.Clear();
            tree.Enqueue(treeRoot);
            while (tree.Count > 0)
            {
                Node<int> node = tree.Dequeue();
                if (node.Childs.Count > 0)
                {
                    foreach (var n in node.Childs)
                    {
                        tree.Enqueue(n);
                        Console.Write(n.Value + " ");
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("All middle leafs");
            tree.Clear();
            tree.Enqueue(treeRoot);
            while (tree.Count > 0)
            {
                Node<int> node = tree.Dequeue();
                if (node.Childs.Count > 0)
                {
                    foreach (var n in node.Childs)
                    {
                        tree.Enqueue(n);
                        if (n.Parent != null && n.Childs.Count != 0)
                        {
                            Console.Write(n.Value + " ");
                        }
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Longest path: ");

            tree.Clear();
            tree.Enqueue(treeRoot);
            while (tree.Count > 0)
            {
                Node<int> node = tree.Dequeue();
                if (node.Childs.Count > 0)
                {
                    foreach (var n in node.Childs)
                    {
                        tree.Enqueue(n);
                        if (n.Parent != null && n.Childs.Count != 0)
                        {
                            Console.Write(n.Value + " ");
                        }
                    }
                }
            }



        }
    }
}
