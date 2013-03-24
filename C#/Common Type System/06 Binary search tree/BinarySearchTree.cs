using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Binary_search_tree
{
    public class BinarySearchTree<T> : ICollection<T>, IEnumerable<T>, ICloneable
    {
        private BinaryTreeNode<T> root;
        private int count = 0;
        private IComparer<T> comparer;

        public int Count { get { return count; } }

        public BinarySearchTree() : this(Comparer<T>.Default) { }
        public BinarySearchTree(Comparer<T> comparer)
        {
            this.root = null;
            this.comparer = comparer;
        }

        public virtual void Clear()
        {
            root = null;
        }

        IEnumerable<T> PreorderTraversal(BinaryTreeNode<T> current, List<T> list)
        {
            if (current != null)
            {
                // Output the value of the current node
                list.Add(current.Value);
                // Recursively print left and right children
                PreorderTraversal(current.Left, list);
                PreorderTraversal(current.Right, list);
            }
            return list;
        }

        IEnumerable<T> InorderTraversal(BinaryTreeNode<T> current, List<T> list)
        {
            //List<T> list = new List<T>();
            if (current != null)
            {
                //Visit left child
                InorderTraversal(current.Left, list);
                // Output the value of the current node
                list.Add(current.Value);
                // Visit the right child
                InorderTraversal(current.Right, list);
            }
            return list;
        }

        IEnumerable<T> PostorderTraversal(BinaryTreeNode<T> current)
        {
            List<T> list = new List<T>();
            if (current != null)
            {
                PostorderTraversal(current.Left);
                PostorderTraversal(current.Right);
                list.Add(current.Value);
            }
            return list;
        }

        public bool Contains(T data)
        {
            // Search the tree for a node that contains data
            BinaryTreeNode<T> current = this.root;
            int result;
            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    return true;
                else if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
            }
            // if this line is reached, data wasn't found
            return false;
        }

        public bool Search(T data)
        {
            return Contains(data);
        }

        public virtual void Add(T data)
        {
            // Create new node instance
            BinaryTreeNode<T> n = new BinaryTreeNode<T>(data);
            int result;
            BinaryTreeNode<T> current = root;
            BinaryTreeNode<T> parent = null;

            while (current != null)
            {
                result = comparer.Compare(current.Value, data);
                if (result == 0)
                    // they are equal - attempting to enter a duplicate - do nothing
                    throw new Exception("Attempting to enter a duplicate data!");
                else if (result > 0)
                {
                    // current.Value > data, must add n to current's left subtree
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // current.Value < data, must add n to current's right subtree
                    parent = current;
                    current = current.Right;
                }
            }

            // We are ready to add the node
            this.count++;
            if (parent == null)
                // the tree was empty, make n root
                root = n;
            else
            {
                result = comparer.Compare(parent.Value, data);
                if (result > 0)
                    parent.Left = n;
                else
                    parent.Right = n;
            }
        }

        public bool Remove(T data)
        {
            // first make sure there exist some items in this tree
            if (root == null)
                return false;       // no items to remove

            // Now, try to find data in the tree
            BinaryTreeNode<T> current = root, parent = null;
            int result = comparer.Compare(current.Value, data);
            while (result != 0)
            {
                if (result > 0)
                {
                    // current.Value > data, if data exists it's in the left subtree
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // current.Value < data, if data exists it's in the right subtree
                    parent = current;
                    current = current.Right;
                }

                // If current == null, then we didn't find the item to remove
                if (current == null)
                    return false;
                else
                    result = comparer.Compare(current.Value, data);
            }

            // At this point, we've found the node to remove
            this.count--;

            // We now need to "rethread" the tree
            // CASE 1: If current has no right child, then current's left child becomes
            //         the node pointed to by the parent
            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make current's left child a left child of parent
                        parent.Left = current.Left;
                    else if (result < 0)
                        // parent.Value < current.Value, so make current's left child a right child of parent
                        parent.Right = current.Left;
                }
            }
            // CASE 2: If current's right child has no left child, then current's right child
            //         replaces current in the tree
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make current's right child a left child of parent
                        parent.Left = current.Right;
                    else if (result < 0)
                        // parent.Value < current.Value, so make current's right child a right child of parent
                        parent.Right = current.Right;
                }
            }
            // CASE 3: If current's right child has a left child, replace current with current's
            //          right child's left-most descendent
            else
            {
                // We first need to find the right node's left-most child
                BinaryTreeNode<T> leftmost = current.Right.Left, lmParent = current.Right;
                while (leftmost.Left != null)
                {
                    lmParent = leftmost;
                    leftmost = leftmost.Left;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                lmParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                    root = leftmost;
                else
                {
                    result = comparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                        // parent.Value > current.Value, so make leftmost a left child of parent
                        parent.Left = leftmost;
                    else if (result < 0)
                        // parent.Value < current.Value, so make leftmost a right child of parent
                        parent.Right = leftmost;
                }
            }

            return true;
        }




        public IEnumerator<T> GetEnumerator()
        {
            IEnumerable<T> list = InorderTraversal(root, new List<T>());
            //IEnumerable<T> list = PreorderTraversal(root, new List<T>());
            foreach (var item in list)
            {
                // Lets check for end of list (its bad code since we used arrays)
                if (item == null)
                {
                    break;
                }

                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public object Clone()
        {
            return CloneBST(root, new BinarySearchTree<T>());           
        }

        private BinarySearchTree<T> CloneBST(BinaryTreeNode<T> current, BinarySearchTree<T> bst)
        {
            if (current != null)
            {
                bst.Add(current.Value);
                CloneBST(current.Left, bst);
                CloneBST(current.Right, bst);
            }
            return bst;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in InorderTraversal(root, new List<T>()))
            {
                str.Append(item);
                str.Append(" ");
            }
            return str.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // TODO after exam!!!
            return base.Equals(obj);
        }

    }
}
