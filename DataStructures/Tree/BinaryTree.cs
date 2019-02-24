using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> _root;
        public BinaryTreeNode<T> Root => this._root;
        public bool IsEmpty => this._root == null;
        public long Count() => GetCount(this.Root);
        public void Add(T value) => Insert(_root, new BinaryTreeNode<T>(value));
        public bool Contains(T value) => Find(_root, value) != null;
        public long GetHeight() => GetHeight(this._root);
        public void Delete(T value)
        {
            var node = Find(_root, value);
            if (node != null)
                Delete(_root, node);

        }
        public IEnumerable<T> Inorder() => Inorder(_root, new List<T>());
        public IEnumerable<T> Preorder() => Preorder(_root, new List<T>());
        public IEnumerable<T> Postorder() => Postorder(_root, new List<T>());
        private void Insert(BinaryTreeNode<T> tree, BinaryTreeNode<T> child)
        {
            BinaryTreeNode<T> temp = null;
            var current = tree;
            while (current != null)
            {
                temp = current;
                //current is greater than child value
                var result = current.CompareTo(child.Value);
                current = result > 0 ? current.Left : current.Right;

            }
            child.Parent = temp;
            if (temp == null)
                this._root = child;
            else if (temp.CompareTo(child.Value) > 0)
                temp.Left = child;
            else
                temp.Right = child;


        }
        private void Delete(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> temp = null;
            if (node.Left == null)
                Transplant(node, node.Right);
            else if (node.Right == null)
                Transplant(node, node.Left);
            else
                temp = Minimum(node.Right);

            if (temp != null)
            {
                if (temp.Parent != node)
                {
                    Transplant(temp, temp.Right);
                    temp.Right = node.Right;
                    temp.Right.Parent = temp;
                }

                Transplant(node, temp);
                temp.Left = node.Left;
                temp.Left.Parent = temp;
            }
        }
        private void Transplant(BinaryTreeNode<T> node, BinaryTreeNode<T> child)
        {
            if (this._root != null)
            {
                if (node.Parent == null)
                    this._root = child;
                else if (node == node.Parent.Left)
                    node.Parent.Left = child;
                else
                    node.Parent.Right = child;

                if (child != null)
                    child.Parent = node.Parent;
            }

        }
        private BinaryTreeNode<T> Minimum(BinaryTreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        private BinaryTreeNode<T> Maximum(BinaryTreeNode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }
        private BinaryTreeNode<T> Find(BinaryTreeNode<T> parent, T value)
        {
            while (true)
            {
                if (parent == null || parent.Value.CompareTo(value) == 0)
                    return parent;

                return parent.Value.CompareTo(value) > 0 ? Find(parent.Left, value) :
                     Find(parent.Right, value);

            }
        }
        private BinaryTreeNode<T> Successor(BinaryTreeNode<T> node)
        {
            if (node.Right != null)
                return Minimum(node.Right);

            var temp = node.Parent;
            while (temp != null && node == temp.Right)
            {
                node = temp;
                temp = temp.Parent;
            }
            return temp;
        }
        private long GetCount(BinaryTreeNode<T> root)
        {
            if (root == null)
                return 0;
            else
            {
                long l = 1;
                l += GetCount(root.Left);
                l += GetCount(root.Right);
                return l;
            }
        }
        private long GetHeight(BinaryTreeNode<T> node)
        {
            if (node == null)
                return -1;

            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }
        private IEnumerable<T> Inorder(BinaryTreeNode<T> root, List<T> items)
        {
            if (root != null)
            {

                Inorder(root.Left, items);
                items.Add(root.Value);
                Inorder(root.Right, items);
            }

            return items;
        }
        private IEnumerable<T> Preorder(BinaryTreeNode<T> root, List<T> items)
        {
            if (root != null)
            {
                items.Add(root.Value);
                Preorder(root.Left, items);
                Preorder(root.Right, items);
            }

            return items;
        }
        private IEnumerable<T> Postorder(BinaryTreeNode<T> root, List<T> items)
        {
            if (root != null)
            {
                Preorder(root.Left, items);
                Preorder(root.Right, items);
                items.Add(root.Value);
            }

            return items;
        }
    }
}
