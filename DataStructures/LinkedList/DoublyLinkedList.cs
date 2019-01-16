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

        public void AddFirst(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
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
            if (item == null)
                throw new ArgumentNullException("item");
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
                return;
            }

            //Else traverse till the last node
            while (last.Next != null)
                last = last.Next;

            //Change the next of last node 
            last.Next = node;

            //Make last node as previous of new node 
            node.Prev = last;

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
    }
}
