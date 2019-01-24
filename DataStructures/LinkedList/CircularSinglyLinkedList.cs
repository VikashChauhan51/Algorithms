﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class CircularSinglyLinkedList<T> : SinglyLinkedListBase<T>
    {
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
        public override void AddFirst(T item)
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
        public override void AddLast(T item)
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
                while (current.Link != head)
                {
                    pre = current;
                    current = current?.Link;
                }
                pre.Link = current?.Link;
                current = pre;

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

            var current = head;
            while (current.Link != head)
                current = current.Link;

            head = head.Link;
            current.Link = head;

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
                while (current.Link != head) //loop till end.
                    current = current.Link;

                head = head.Link;
                current.Link = head;
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

        public override bool AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new Node<T>(item);
            if (current != null && IsEquals(current.Data, nodeData))
            {
                while (current.Link != head)//loop till end.
                    current = current.Link;

                node.Link = head;
                head = node;

                current.Link = node;
                count++;
                return true;
            }
            else
            {
                while (current != null && current.Link != head)
                {
                    if (IsEquals(current.Link.Data, nodeData))
                    {
                        node.Link = current.Link;
                        current.Link = node;
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
            do
            {
                if (current != null && IsEquals(current.Data, nodeData))
                {
                    var node = new Node<T>(item);
                    node.Link = current.Link;
                    current.Link = node;
                    count++;
                    return true;
                }
                current = current?.Link;
            } while (current != head);
            return false;
        }
 
        public override T GetLast()
        {
            var current = head;
            while (current.Link != head)
                current = current.Link;

            return GetData(current);
        }
        
        public override IEnumerable<T> Get()
        {
            var current = head;
            do
            {
                if (current != null)
                {
                    yield return GetData(current);
                    current = current?.Link;
                }

            } while (current != head);

        }
        public override bool Contains(T item)
        {
            var current = head;
            do
            {
                if (current != null && IsEquals(current.Data, item))
                    return true;

                current = current?.Link;

            } while (current != head);

            return false;
        }

        public override void CopyTo(T[] array, int index)
        {
            var current = head;
            do
            {
                array[index++] = GetData(current);
                current = current?.Link;

            } while (current != head);
        }
 
    }
}
