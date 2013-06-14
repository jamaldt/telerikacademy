// * We are given numbers N and M and the following operations:
// N = N+1
// N = N+2
// N = N*2
// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
// Example: N = 5, M = 16
// Sequence: 5  7  8  16

using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Shortest_seq.of_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 113;
            int m = 1834;
            Node<int> tree = new Node<int>(n);
            Queue<Node<int>> nodeQueue = new Queue<Node<int>>();
            nodeQueue.Enqueue(tree);
            ISet<int> numbers = new HashSet<int>() {tree.Value};


            while (nodeQueue.Count > 0)
            {
                Node<int> parent = nodeQueue.Dequeue();

                int a = CalcA(parent.Value);
                NewMethod(m, nodeQueue, numbers, parent, a);

                int b = CalcB(parent.Value);
                NewMethod(m, nodeQueue, numbers, parent, b);

                int c = CalcC(parent.Value);
                NewMethod(m, nodeQueue, numbers, parent, c);
            }

            //PrintTree(tree);
            PrintShortestCombination(m, tree, nodeQueue);

        }

        private static void PrintShortestCombination(int m, Node<int> tree, Queue<Node<int>> nodeQueue)
        {
            StringBuilder treeOutput = new StringBuilder();
            // Find shortest combination
            // Print custom tree
            treeOutput.AppendLine(tree.Value.ToString());
            nodeQueue.Enqueue(tree);
            bool exit = false;
            Node<int> containsM = null;
            while (nodeQueue.Count > 0)
            {
                Node<int> parent = nodeQueue.Dequeue();
                foreach (var node in parent.Childs)
                {
                    if (node.Value == m)
                    {
                        exit = true;
                        containsM = node;
                        break;
                    }

                    nodeQueue.Enqueue(node);
                }

                if (exit)
                {
                    break;
                }
            }

            while (containsM.Parent != null)
            {
                Console.Write(containsM.Value.ToString() + " ");
                containsM = containsM.Parent;
            }

            Console.Write(tree.Value);
            Console.WriteLine();
        }

        private static void PrintTree(Node<int> tree)
        {
            // Print custom tree
            StringBuilder treeOutput = new StringBuilder();
            treeOutput.AppendLine(tree.Value.ToString());
            Queue<Node<int>> nodeQueue = new Queue<Node<int>>();
            nodeQueue.Enqueue(tree);
            while (nodeQueue.Count > 0)
            {
                Node<int> parent = nodeQueue.Dequeue();
                foreach (var node in parent.Childs)
                {
                    treeOutput.Append(node.Value.ToString());
                    treeOutput.Append(" ");
                    nodeQueue.Enqueue(node);
                }
                treeOutput.AppendLine();
            }

            Console.WriteLine(treeOutput.ToString());
        }

        private static void NewMethod(int m, Queue<Node<int>> nodeQueue, ISet<int> numbers, Node<int> parent, int a)
        {
            if (!numbers.Contains(a) && a <= m)
            {
                numbers.Add(a);
                Node<int> leaf = new Node<int>(a, parent);
                parent.Add(leaf);
                nodeQueue.Enqueue(leaf);
            }
        }

        private static int CalcC(int p)
        {
            return p + 1;
        }

        private static int CalcB(int p)
        {
            return p + 2;
        }

        private static int CalcA(int p)
        {
            return p * 2;
        }
    }
}
