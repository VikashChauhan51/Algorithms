using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class DoublyLinkedList<T>: DoublyLinkedListBase<T>
    {
         
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

        public override void AddFirst(T item)
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

        public override void AddLast(T item)
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

        public override bool AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new DoublyNode<T>(item);
            if (current != null && IsEquals(current.Data, nodeData))
            {
                current.Prev = node;
                node.Next = current;
                head = node;
                count++;
                return true;
            }
            else
            {
                while (current != null && current.Next != null)
                {

                    if (IsEquals(current.Next.Data, nodeData))
                    {
                        node.Next = current.Next;
                        node.Prev = current;
                        current.Next = node;
                        count++;
                        return true;
                    }
                    current = current.Next;
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
                    var node = new DoublyNode<T>(item);
                    node.Prev = current;
                    node.Next = current.Next;
                    current.Next = node;
                    count++;
                    return true;
                }
                current = current.Next;
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
                while (current.Next != null)
                {
                    current = current?.Next;
                }
                current.Prev.Next = null;

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

            head = head.Next;
            head.Prev = null;
            count--;
            return true;
        }

        public override bool Remove(T item)
        {
            var current = head;
            // If head node itself holds the key to be deleted 
            if (current != null && (IsEquals(current.Data, item)))
            {
                head = current.Next;   // Changed head 
                current = null;       // free old head 
                count--;
                return true;
            }

            // Search for the key to be deleted, keep track of the 
            // previous node as we need to change 'prev->next' 
            while (current != null && !(IsEquals(current.Data, item)))
            {
                current = current.Next;
            }

            // If key was not present in linked list 
            if (current == null) return false;

            // Unlink the node from linked list 
            current.Prev.Next = current.Next;
            count--;
            return true;
        }

        public override IEnumerable<T> Get()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }

        }

        public override bool Contains(T item)
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

        public override void CopyTo(T[] array, int index)
        {
            var current = head;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
        }
 
        /// <summary>
        /// Get last node.
        /// </summary>
        /// <returns></returns>
        public override T GetLast()
        {
            var current = head;
            while (current.Next != null)
                current = current.Next;

            return GetData(current);
        }
 
    }
}
