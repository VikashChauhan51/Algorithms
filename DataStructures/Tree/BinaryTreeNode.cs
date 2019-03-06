using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable
    {
        private BinaryTreeNode<T> _parent;
        private T _value;
        private BinaryTreeNode<T> _left { get; set; }
        private BinaryTreeNode<T> _right { get; set; }
        public bool IsLeaf => _left == null && _right == null;
        public T Value { get => _value; set => _value = value; }
        public bool IsFull => _left != null && _right != null;
        public BinaryTreeNode<T> Left { get => _left; set => _left = value; }
        public BinaryTreeNode<T> Right { get => _right; set => _right = value; }
        public BinaryTreeNode<T> Parent { get => _parent; set => _parent = value; }
        public BinaryTreeNode<T> Sibling => Parent.Left == this ?
                                                Parent.Right : Parent.Left;
        public BinaryTreeNode()
        {

        }
        public BinaryTreeNode(T value)
        {
            this._value = value;
        }

        public int CompareTo(T obj)
        {
            if (Value == null)
                return obj == null ? 0 : -1;
            else
                return Value.CompareTo(obj);

        }
        public IEnumerable<BinaryTreeNode<T>> Ancestors()
        {
            var current = this.Parent;
            while (current != null)
            {
                yield return current;
                current = current.Parent;
            }
        }
        public IEnumerable<BinaryTreeNode<T>> Descendants() => Descendants(this, new List<BinaryTreeNode<T>>());
        private IEnumerable<BinaryTreeNode<T>> Descendants(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> items)
        {
            if (node != null)
            {
                items.Add(node);
                Descendants(node.Left, items);
                Descendants(node.Right, items);
            }
            return items;
        }
    }
}
