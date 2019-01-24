using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T> : SinglyLinkedListBase<T>
    {
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
  
        public override T GetLast()
        {
            var current = head;
            while (current.Link != null)
                current = current.Link;

            return GetData(current);
        }


        /// <summary>
        /// Add node head of the list.
        /// </summary>
        /// <param name="item"></param>
        public override void AddFirst(T item)
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
        public override void AddLast(T item)
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
        public override bool AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new Node<T>(item);
            if (current != null && IsEquals(current.Data, nodeData))
            {
                node.Link = current;
                head = node;
                count++;
                return true;
            }
            else
            {
                while (current != null && current.Link != null)
                {
                    var perv = current;
                    if (IsEquals(current.Link.Data, nodeData))
                    {
                        node.Link = current.Link;
                        perv.Link = node;
                        count++;
                        return true;
                    }
                    current = current.Link;
                }
            }
            return false;
        }
        public override bool AddAfter(T nodeData, T item)
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
                    return true;
                }
                current = current.Link;
            }

            return false;
        }
        /// <summary>
        /// Remove node from tail of list.
        /// </summary>
        public override bool RemoveLast()
        {
            if (head == null || count == 0)
                return false;

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
            return true;
        }
        /// <summary>
        /// Remove node from head of list.
        /// </summary>
        public override bool RemoveFirst()
        {
            if (head == null || count == 0)
                return false;

            head = head.Link;
            count--;
            return true;
        }

        public override bool Remove(T item)
        {
            var current = head;
            Node<T> prev = null;
            // If head node itself holds the key to be deleted 
            if (current != null && (IsEquals(current.Data, item)))
            {
                head = current.Link;   // Changed head 
                current = null;       // free old head 
                count--;
                return true;
            }

            // Search for the key to be deleted, keep track of the 
            // previous node as we need to change 'prev->next' 
            while (current != null && !(IsEquals(current.Data, item)))
            {
                prev = current;
                current = current.Link;
            }

            // If key was not present in linked list 
            if (current == null) return false;

            // Unlink the node from linked list 
            prev.Link = current.Link;

            count--;
            return true;
        }
        public override IEnumerable<T> Get()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Link;
            }

        }
        public override bool Contains(T item)
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

        public override void CopyTo(T[] array, int index)
        {
            var current = head;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Link;
            }
        }


    }
}
