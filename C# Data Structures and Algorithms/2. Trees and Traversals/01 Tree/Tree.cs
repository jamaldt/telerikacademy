using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Tree
{
    class Tree<T>
    {
        private Node<T> root;

        public Tree(T value)
        {
            this.root = new Node<T>(value);
        }
    }
}
