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
        /// <param name="collection"> <see cref="IEnumerable{T}"/></param>
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
                AddFirst(item);

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
            while (current.Link != null)
                current = current.Link;

            return GetData(current);
        }
        /// <summary>
        /// Get list count.
        /// </summary>
        /// <returns></returns>
        public long Count()=> count;

        /// <summary>
        /// Check is list empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => head == null;

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
        /// <param name="item"></param>
        public void AddLast(T item)
        { 
            //create node.
            var node = new Node<T>(item);
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
        public void AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new Node<T>(item);
            if (IsEquals(head.Data, nodeData))
            {
                node.Link = current;
                head = node;
                count++;
            }
            else
            {
                while (current.Link != null)
                {
                    var perv = current;
                    if (IsEquals(current.Link.Data, nodeData))
                    {
                        node.Link = current.Link;
                        perv.Link = node;
                        count++;
                        return;
                    }
                    current = current.Link;
                }
            }
        }
        public void AddAfter(T nodeData, T item)
        {
            var current = head;

            while (current != null)
            {
                if (IsEquals(current.Data, nodeData))
                {
                    var node = new Node<T>(item);
                    node.Link = current.Link;
                    current.Link = node;
                    count++;
                    return;
                }
                current = current.Link;
            }
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
                throw new ArgumentOutOfRangeException(nameof(head));

            head = head.Link;
            count--;
        }

        public void Remove(T item)
        {
            var current = head;
            Node<T> prev = null;
            // If head node itself holds the key to be deleted 
            if (current != null && (IsEquals(current.Data, item)))
            {
                head = current.Link;   // Changed head 
                current = null;       // free old head 
                count--;
                return;
            }

            // Search for the key to be deleted, keep track of the 
            // previous node as we need to change 'prev->next' 
            while (current != null && !(IsEquals(current.Data, item)))
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
