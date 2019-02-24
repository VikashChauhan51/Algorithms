using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public BinaryTreeNode(T value)
        {
            this._value = value;
        }
        
        public int CompareTo(T obj)=> Value.CompareTo(obj);
    }
}
