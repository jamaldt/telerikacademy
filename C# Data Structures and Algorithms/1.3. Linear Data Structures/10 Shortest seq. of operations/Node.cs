using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Shortest_seq.of_operations
{
    public class Node<T>
    {
        private List<Node<T>> chiledNodes = new List<Node<T>>();

        public Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, Node<T> parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("Parent node can't be null");
            }

            this.Value = value;
            this.Parent = parent;
        }

        public T Value { get; set; }
        public Node<T> Parent { get; set; }

        public void Add(Node<T> leaf)
        {
            if (leaf == null)
            {
                throw new ArgumentNullException("Leaf node can't be null");
            }

            this.chiledNodes.Add(leaf);
        }

        public IEnumerable<Node<T>> Childs
        {
            get
            {
                // TODO: make defensive copy
                return this.chiledNodes;
            }
        }
    }
}
