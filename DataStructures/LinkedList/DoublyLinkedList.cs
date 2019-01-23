using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class DoublyLinkedList<T>
    {
        DoublyNode<T> head;
        private long count;
        public DoublyLinkedList()
        {

        }
        /// <summary>
        /// Instantiate with node(s).
        /// </summary>
        /// <param name="collection"> <see cref="IEnumerable{T}"/></param>
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
                AddFirst(item);

        }

        public void AddFirst(T item)
        {
  
            //create node.
            var node = new DoublyNode<T>(item);
            // Make next of new node as head and previous as null.
            node.Next = head;
            node.Prev = null;

            //change prev of head node to new null.
            if (head != null)
                head.Prev = node;

            //move the head to point to the new node
            head = node;
            count++;
        }

        public void AddLast(T item)
        {
          
            //create node.
            var node = new DoublyNode<T>(item);
            var  last = head;

            /* This new node is going to be the last node, so 
             * make next of it as null*/
            node.Next = null;

            /* If the Linked List is empty, then make the new 
             * node as head */
            if (head == null)
            {
                node.Prev = null;
                head = node;
                count++;
                return;
            }

            //Else traverse till the last node
            while (last.Next != null)
                last = last.Next;

            //Change the next of last node 
            last.Next = node;

            //Make last node as previous of new node 
            node.Prev = last;
            count++;

        }

        public void AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new DoublyNode<T>(item);
            if (IsEquals(head.Data, nodeData))
            {
                current.Prev = node;
                node.Next = current;
                head = node;
                count++;
            }
            else
            {
                while (current.Next != null)
                {

                    if (IsEquals(current.Next.Data, nodeData))
                    {
                        node.Next = current.Next;
                        node.Prev = current;
                        current.Next = node;
                        count++;
                        return;
                    }
                    current = current.Next;
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
                    var node = new DoublyNode<T>(item);
                    node.Prev = current;
                    node.Next = current.Next;
                    current.Next = node;
                    count++;
                    return;
                }
                current = current.Next;
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
                while (current.Next != null)
                {
                    current = current?.Next;
                }
                current.Prev.Next = null;

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

            head = head.Next;
            head.Prev = null;
            count--;
        }

        public void Remove(T item)
        {
            var current = head;
            // If head node itself holds the key to be deleted 
            if (current != null && (IsEquals(current.Data, item)))
            {
                head = current.Next;   // Changed head 
                current = null;       // free old head 
                count--;
                return;
            }

            // Search for the key to be deleted, keep track of the 
            // previous node as we need to change 'prev->next' 
            while (current != null && !(IsEquals(current.Data, item)))
            {
                current = current.Next;
            }

            // If key was not present in linked list 
            if (current == null) return;

            // Unlink the node from linked list 
            current.Prev.Next = current.Next;
            count--;
        }

        public IEnumerable<T> Get()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        public bool Contains(T item)
        {
            var current = head;
            while (current != null)
            {
                if (IsEquals(current.Data, item))
                    return true;

                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            var current = head;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
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
            while (current.Next != null)
                current = current.Next;

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
        public bool IsEmpty()=> head == null;

        public void Clear()
        {
            head = null;
            count = 0;
        }
        private bool IsEquals(T source, T item) => (source == null && item == null) || source.Equals(item);
        private T GetData(DoublyNode<T> node) => node != null ? node.Data : default(T);
    }
}
