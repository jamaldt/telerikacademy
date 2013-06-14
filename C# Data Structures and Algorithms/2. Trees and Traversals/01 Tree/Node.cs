using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Tree
{
    internal class Node<T>
    {
        public Node(T value, Node<T> parent = null)
        {
            this.Parent = parent;
            this.Childs = new List<Node<T>>();
            this.Value = value;
        }

        public Node<T> Parent { get; set; }
        public List<Node<T>> Childs { get; set; }
        public T Value { get; set; }

        public void Add(T value)
        {
            CheckForNull(value, "Leaf's value can't be null");
            Node<T> leaf = new Node<T>(value);
            this.Childs.Add(leaf);
        }

        private static void CheckForNull<M>(M value, string msg)
        {
            if (value == null)
            {
                throw new ArgumentNullException(msg);
            }
        }
    }
}
