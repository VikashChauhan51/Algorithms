using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class CircularSinglyLinkedList<T>
    {
        private Node<T> head;
        private long count;
        /// <summary>
        /// Default constructor
        /// </summary>
        public CircularSinglyLinkedList()
        {

        }

        /// <summary>
        /// Instantiate with nodes.
        /// </summary>
        /// <param name="collection"> <see cref="IEnumerable{T}"/></param>
        public CircularSinglyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
                AddFirst(item);

        }
        /// <summary>
        /// Add node head of the list.
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            //create node.
            var node = new Node<T>(item);

            //Add first node.
            if (head == null)
            {
                head = node;
                head.Link = head;
            }
            else
            {
                var current = head;
                while (current.Link != head)
                    current = current.Link;

                node.Link = head;
                head = node;
                current.Link = head;
               
            }

            count++;
        }

        /// <summary>
        /// Add node tail of list.
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            //create node.
            var node = new Node<T>(item);
            //Add first node.
            if (head == null)
            {
                head = node;
                head.Link = head;
            }
            else
            {
                var current = head;
                while (current.Link != head)
                    current = current.Link;

                current.Link = node;
                node.Link = head;
            }

            count++;

        }

        /// <summary>
        /// Remove node from tail of list.
        /// </summary>
        public void RemoveLast()
        {
            if (head == null || count == 0)
                throw new ArgumentOutOfRangeException(nameof(head));

            if (count == 1)
            {
                head = null;
            }
            else
            {
                var current = head;
                Node<T> pre = null;
                while (current.Link != head)
                {
                    pre = current;
                    current = current?.Link;
                }
                pre.Link = current?.Link;
                current.Link = head;

            }
            count--;
        }
        /// <summary>
        /// Remove node from head of list.
        /// </summary>
        public void RemoveFirst()
        {
            if (head == null || count == 0)
                throw new ArgumentOutOfRangeException(nameof(head));

            var current = head;
            while (current.Link != head)
                current = current.Link;

            head = head.Link;
            current.Link = head;

            count--;
        }

        /// <summary>
        /// Get top node data.
        /// </summary>
        /// <returns></returns>
        public T GetFirst()
        {
            return GetData(head);
        }
        /// <summary>
        /// Get last node.
        /// </summary>
        /// <returns></returns>
        public T GetLast()
        {
            var current = head;
            while (current.Link != head)
                current = current.Link;

            return GetData(current);
        }
        /// <summary>
        /// Get list count.
        /// </summary>
        /// <returns></returns>
        public long Count() => count;

        /// <summary>
        /// Check is list empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => head == null;
        public IEnumerable<T> Get()
        {
            var current = head;
            while (current.Link != head)
            {
                yield return current.Data;
                current = current.Link;
            }

            yield return current.Data;

        }
        public bool Contains(T item)
        {
            var current = head;
            while (current != null)
            {
                if (IsEquals(current.Data, item))
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
        private bool IsEquals(T source, T item) => (source == null && item == null) || source.Equals(item);
        private T GetData(Node<T> node) => node != null ? node.Data : default(T);
    }
}
