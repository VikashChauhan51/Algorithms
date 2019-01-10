using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T>
    {
        private Node<T> head;
        private long count;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SinglyLinkedList()
        {

        }
        /// <summary>
        /// Instantiate with nodes.
        /// </summary>
        /// <param name="collection"> <see cref="IEnumerable{Node<typeparamref name="T"/>}"/></param>
        public SinglyLinkedList(IEnumerable<Node<T>> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            foreach (var item in collection)
                AddFirst(item);

        }
        /// <summary>
        /// Get top node.
        /// </summary>
        /// <returns><see cref="Node{T}"/></returns>
        public Node<T> First()
        {
            return head;
        }
        /// <summary>
        /// Get last node.
        /// </summary>
        /// <returns><see cref="Node{T}"/></returns>
        public Node<T> Last()
        {
            var current = head;
            while (current.Link != null)
                current = current.Link;

            return current;
        }
        /// <summary>
        /// Get list count.
        /// </summary>
        /// <returns></returns>
        public long Count()
        {
            return count;

        }
        /// <summary>
        /// Check is list empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }
        /// <summary>
        /// Add node head of the list.
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(Node<T> node)
        {
            //Add first node.
            if (head == null)
            {
                head = node;
                head.Link = null;
            }
            else
            {
                var temp = head;
                head = node;
                head.Link = temp;
            }

            count++;
        }
        /// <summary>
        /// Add node tail of list.
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(Node<T> node)
        {
            //Add first node.
            if (head == null)
            {
                head = node;
                head.Link = null;
            }
            else
            {
                var current = head;
                while (current.Link != null)
                    current = current.Link;

                current.Link = node;
            }

            count++;

        }
    }
}
