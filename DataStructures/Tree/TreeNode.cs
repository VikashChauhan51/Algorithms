using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataStructures.Tree
{
    public class TreeNode<T> : IComparable<T> where T : IComparable
    {
        private T _value;
        private TreeNode<T> _parent;
        private SinglyLinkedList<TreeNode<T>> children;
        public bool IsLeaf => Children.Count() == 0;
        /// <summary>Constructs a tree node</summary>
        /// <param name="value">the value of the node</param>
        public TreeNode(T value)
        {
            this._value = value;
            this.children = new SinglyLinkedList<TreeNode<T>>();
        }
        public TreeNode(TreeNode<T> parent, T value)
        {
            _parent = parent;
            _value = value;
            this.children = new SinglyLinkedList<TreeNode<T>>();
        }

        public T Value { get => _value; set => _value = value; }
        public TreeNode<T> Parent { get => _parent; set => _parent = value; }
        public long ChildrenCount => this.children.Count();
        public IEnumerable<TreeNode<T>> Children => this.children.Get();

        /// <summary>Adds child to the node</summary>
        /// <param name="child">the child to be added</param>
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            if (child.ChildrenCount > 0)
                throw new ArgumentException("The node already has a parent!");

            child.Parent = this;
            this.children.AddLast(child);

        }

        public void DeleteChild(TreeNode<T> child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            if (child.Parent != this)
                throw new ArgumentException("The node already has a different parent!");

            this.children.Remove(child);
        }
        /// <summary>
        /// Gets the child of the node.It will return first node if duplicate exists.
        /// </summary>
        /// <param name="value">the value of the desired child</param>
        /// <returns>the child on the given value</returns>
        public TreeNode<T> GetChild(T value)
        {
            return this.children.Get().Where(x => x.Value.CompareTo(value) == 0).FirstOrDefault();
        }
        public void RemoveAllChilds()
        {
            this.children = new SinglyLinkedList<TreeNode<T>>();
        }
        public TreeNode<T> GetFirstChild()
        {
            return this.children.Get().FirstOrDefault();
        }
        public int CompareTo(T obj)
        {
            if (Value == null)
                return obj == null ? 0 : -1;
            else
                return Value.CompareTo(obj);

        }

        public IEnumerable<TreeNode<T>> Ancestors()
        {
            var current = this.Parent;
            while (current != null)
            {
                yield return current;
                current = current.Parent;
            }
        }
        public IEnumerable<TreeNode<T>> Descendants() => Descendants(this, new List<TreeNode<T>>());

        private IEnumerable<TreeNode<T>> Descendants(TreeNode<T> node, List<TreeNode<T>> items)
        {
            if (node != null && node.Children != null)
                foreach (var child in node.Children)
                {
                    items.Add(child);
                    Descendants(child, items);

                }

            return items;
        }
        public IEnumerable<TreeNode<T>> Sibling()
        {
            if (this.Parent != null && this.Parent.Children != null)
                foreach (var child in this.Parent.Children)
                    if (child != this)
                        yield return child;
        }
    }
}
