using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    /// <summary>Represents a tree data structure</summary>
    /// <typeparam name="T">the type of the values in the tree</typeparam
    public class Tree<T> where T : IComparable
    {
        private TreeNode<T> _root;
        private long _count;

        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the node</param>
        public Tree(T value)
        {
            Insert(default(T), value);
        }
        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the root node</param>
        /// <param name="children">the children of the root node</param>
        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
                this._root.AddChild(child._root);
        }

        /// <summary>
        /// The root node or null if the tree is empty.
        /// </summary>
        public TreeNode<T> Root => this._root;
        public long Count => _count;

        public IEnumerable<T> Get() => TraverseDFS(this._root,new List<T>());
        /// <summary>
        /// Time complexity:  O(n)
        /// </summary>
        public IEnumerable<T> Children(T value) => Find(this._root, value)?.Children.Select(x => x.Value);
        /// <summary>
        /// Time complexity:  O(n)
        /// </summary>
        public bool HasItem(T value) => Find(_root, value) != null;
        /// <summary>
        /// Time complexity:  O(n)
        /// </summary>
        public int GetHeight() => GetHeight(_root);

        /// <summary>
        /// Time complexity:  O(n)
        /// </summary>
        public void Insert(T parent, T child)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(child);
                _count++;
                return;
            }

            var parentNode = Find(_root, parent);

            if (parentNode == null)
                throw new ArgumentNullException(nameof(parentNode));

            parentNode.AddChild(new TreeNode<T>(child));
            _count++;
        }
        /// <summary>
        /// Time complexity:  O(n)
        /// </summary>
        public void Delete(T value)=> Delete(_root.Value, value);
        private TreeNode<T> Find(TreeNode<T> parent, T value)
        {
            if (parent == null || parent.Value.CompareTo(value) == 0)
                return parent;

            foreach (var child in parent.Children)
            {
                var result = Find(child, value);

                if (result != null)
                    return result;
            }

            return null;
        }
        private void Delete(T parentValue, T value)
        {
            var parent = Find(_root, parentValue);

            if (parent == null)
                throw new Exception("Cannot find parent");

            var itemToRemove = Find(parent, value);

            if (itemToRemove == null)
            {
                throw new Exception("Cannot find item");
            }

            //if item is root
            if (itemToRemove.Parent == null)
            {
                if (itemToRemove.Children.Count() == 0)
                {
                    _root = null;
                }
                else
                {
                    if (itemToRemove.Children.Count() == 1)
                    {
                        _root = itemToRemove.GetFirstChild();
                        itemToRemove.RemoveAllChilds();
                        _root.Parent = null;
                    }
                    else
                        throw new Exception("Node have multiple children. Cannot delete node unambiguosly");
                }

            }
            else
            {
                if (itemToRemove.Children.Count() == 0)
                {
                    itemToRemove.Parent.DeleteChild(itemToRemove);
                }
                else
                {
                    if (itemToRemove.Children.Count() == 1)
                    {
                        var orphan = itemToRemove.GetFirstChild();
                        orphan.Parent = itemToRemove.Parent;
                        itemToRemove.RemoveAllChilds();
                        itemToRemove.Parent.AddChild(orphan);
                        itemToRemove.Parent.DeleteChild(itemToRemove);
                    }
                    else
                        throw new Exception("Node have multiple children. Cannot delete node unambiguosly");
                }
            }

            _count--;

        }
        private int GetHeight(TreeNode<T> node)
        {
            if (node == null)
                return -1;

            var currentHeight = -1;

            foreach (var child in node.Children)
            {
                var childHeight = GetHeight(child);

                if (currentHeight < childHeight)
                    currentHeight = childHeight;
            }

            currentHeight++;

            return currentHeight;
        }
        private IEnumerable<T> TraverseDFS(TreeNode<T> node,List<T> items)
        {
             
            if (node != null)
            {
                items.Add(node.Value);

                 foreach (var item in node.Children)
                    TraverseDFS(item, items);
            }

            return items;
        }

    }
}
