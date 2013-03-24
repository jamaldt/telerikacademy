using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Binary_search_tree
{
    public class BinaryTreeNode<T>
    {
        private T data;
        private BinaryTreeNode<T> left;
        private BinaryTreeNode<T> right;

        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        public BinaryTreeNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        public BinaryTreeNode<T> Right 
        {
            get { return right; }
            set { right = value; }
        }

        public BinaryTreeNode() { }
        public BinaryTreeNode(T data)
        {
            this.Value = data;
            this.Left = null;
            this.Right = null;
        }

    }
}
