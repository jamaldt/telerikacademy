using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Binary_search_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            Random rand = new Random();
            for (int i = 0; i < 29; i++)
            {
                try
                {
                    int item = rand.Next(100000);
                    Console.WriteLine(item);
                    bst.Add(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine("You have tried to insert duplicate item in to the BST");
                }
            }
            Console.WriteLine();
            foreach (var item in bst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nCloning:");
            BinarySearchTree<int> cloneBst = (BinarySearchTree<int>)bst.Clone();
            foreach (var item in cloneBst)
            {
                Console.WriteLine("clone item: " + item);
            }
            Console.WriteLine("\n\nWhat does ToString prints?");
            Console.WriteLine(bst);
        }
    }
}
