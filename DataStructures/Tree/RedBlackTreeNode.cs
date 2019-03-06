using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{

    public enum RedBlackTreeNodeColor
    {
        Black,
        Red
    }

    public class RedBlackTreeNode<T> : IComparable<T> where T : IComparable
    {
        public RedBlackTreeNodeColor Color { get; set; }

        public RedBlackTreeNode<T> Sibling => Parent.Left == this ?
                                                Parent.Right : Parent.Left;
        private RedBlackTreeNode<T> _parent;
        private T _value;
        private RedBlackTreeNode<T> _left { get; set; }
        private RedBlackTreeNode<T> _right { get; set; }
        public bool IsLeaf => _left == null && _right == null;
        public T Value { get => _value; set => _value = value; }
        public bool IsFull => _left != null && _right != null;
        public RedBlackTreeNode<T> Left { get => _left; set => _left = value; }
        public RedBlackTreeNode<T> Right { get => _right; set => _right = value; }
        public RedBlackTreeNode<T> Parent { get => _parent; set => _parent = value; }
        public RedBlackTreeNode()
        {

        }
        public RedBlackTreeNode(T value)
        {
            this._value = value;
            this.Color = RedBlackTreeNodeColor.Black;
        }
        public IEnumerable<RedBlackTreeNode<T>> Ancestors()
        {
            var current = this.Parent;
            while (current != null)
            {
                yield return current;
                current = current.Parent;
            }
        }
        public IEnumerable<RedBlackTreeNode<T>> Descendants() => Descendants(this, new List<RedBlackTreeNode<T>>());
        private IEnumerable<RedBlackTreeNode<T>> Descendants(RedBlackTreeNode<T> node, List<RedBlackTreeNode<T>> items)
        {
            if (node != null)
            {
                items.Add(node);
                Descendants(node.Left, items);
                Descendants(node.Right, items);
            }
            return items;
        }
        public int CompareTo(T obj)
        {
            if (Value == null)
                return obj == null ? 0 : -1;
            else
                return Value.CompareTo(obj);

        }
    }
}
