using System;
using System.Collections.Generic;

namespace Task1.TreeNodesTasks
{
    public class TreeNode<T>
    {
        public TreeNode<T> ParrantNode { get; set; }
        public List<TreeNode<T>> ChildrenNodes { get; set; }
        public T Value { get; set; }
        public bool IsChecked { get; set; }

        public TreeNode(T value, 
            TreeNode<T> parrentNode = null, 
            List<TreeNode<T>> childrenNodes = null)
        {
            this.Value = value;
            this.ParrantNode = parrentNode;
            this.ChildrenNodes = new List<TreeNode<T>>();
            if (childrenNodes != null)
            {
                foreach (var node in childrenNodes)
                {
                    this.ChildrenNodes.Add(node);
                }
            }
        }
    }
}
