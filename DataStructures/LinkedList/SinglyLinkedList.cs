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

        public override T GetLast()=> GetData(GetLastNode());
        
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
                var last = GetLastNode();
                last.Link = node;
            }

            count++;

        }
        public override bool AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new Node<T>(item);
            Node<T> pre = null;
            do
            {
                if (current != null && IsEquals(current.Data, nodeData))
                {
                    node.Link = current;
                    if (current == head)
                        head = node;
                    else
                        pre.Link = node;

                    count++;
                    return true;
                }
                pre = current;
                current = current?.Link;

            } while (current != null);

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

            var current = head;
            Node<T> pre = null;
            //loop till end.
            while (current != null && current.Link != null)
            {
                pre = current;
                current = current.Link;
            }

             
            if (pre != null)
                pre.Link = current?.Link;
            else
                head = current?.Link;

            if(current!=null)
            current.Link = null;

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
            Node<T> pre = null;
            do
            {
                if (current != null && (IsEquals(current.Data, item)))
                {
                    if (pre != null)
                        pre.Link = current.Link;
                    else
                        head = current.Link;

                    count--;
                    return true;
                }
                pre = current;
                current = current?.Link;

            } while (current != null);

            return false;
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
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (array.Length - index < count)
                throw new ArgumentException(nameof(index));

            var current = head;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Link;
            }
        }

        private Node<T> GetLastNode()
        {
            var current = head;
            while (current != null && current.Link != null)
                current = current.Link;
            return current;
        }

    }
}
