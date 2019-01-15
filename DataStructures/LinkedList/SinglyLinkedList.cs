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
        /// Instantiate with nodes.
        /// </summary>
        /// <param name="collection"> <see cref="IEnumerable{T}"/></param>
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            foreach (var item in collection)
                AddFirst(new Node<T>(item));

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
        public T GetFirst()
        {
            return head != null ? head.Data : default(T);
        }
        public T GetLast()
        {
            var current = head;
            while (current.Link != null)
                current = current.Link;

            return current != null ? current.Data : default(T);
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
            if (node == null)
                throw new ArgumentNullException("node");

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
        public void AddFirst(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            AddFirst(new Node<T>(item));

        }
        /// <summary>
        /// Add node tail of list.
        /// </summary>
        /// <param name="node"></param>
        public void AddLast(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

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
        public void AddLast(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            AddLast(new Node<T>(item));

        }
        /// <summary>
        /// Remove node from tail of list.
        /// </summary>
        public void RemoveLast()
        {
            if (head == null || count == 0)
                throw new ArgumentOutOfRangeException("empty");

            if (count == 1)
            {
                head = null;
            }
            else
            {
                var current = head;
                Node<T> pre = null;
                while (current.Link != null)
                {
                    pre = current;
                    current = current?.Link;
                }
                pre.Link = current?.Link;
                current.Link = null;
                
            }
            count--;
        }
        /// <summary>
        /// Remove node from head of list.
        /// </summary>
        public void RemoveFirst()
        {
            if (head == null || count == 0)
                throw new ArgumentOutOfRangeException("empty");

            head = head.Link;
            count--;
        }

        public void Remove(T item)
        {
            var current = head;
            Node<T> prev = null;
            // If head node itself holds the key to be deleted 
            if (current != null && current.Data.Equals(item))
            {
                head = current.Link;   // Changed head 
                current = null;       // free old head 
                return;
            }

            // Search for the key to be deleted, keep track of the 
            // previous node as we need to change 'prev->next' 
            while (current != null && !current.Data.Equals(item))
            {
                prev = current;
                current = current.Link;
            }

            // If key was not present in linked list 
            if (current == null) return;

            // Unlink the node from linked list 
            prev.Link = current.Link;

            count--;
        }
        public IEnumerable<T> Get()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Link;
            }

        }
        public bool Contains(T item)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;

                current = current.Link;
            }
            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            var current = head;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Link;
            }
        }
        public void Clear()
        {
            head = null;
            count = 0;
        }
    }
}
