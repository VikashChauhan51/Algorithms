using System;
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
                AddLast(item);

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
                var last = GetLastNode();

                node.Link = head;
                head = node;
                last.Link = head;

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
                var last = GetLastNode();

                last.Link = node;
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

            var last = GetLastNode();
            //check list having only one item.
            head = head.Link != head ? head.Link : null;
            last.Link = count > 1 ? head : null;

            count--;
            return true;
        }

        public override bool Remove(T item)
        {
            var current = head;
            Node<T> prev = null;

            do
            {
                if (current != null && (IsEquals(current.Data, item)))
                {
                    var last = GetLastNode();

                    if (prev == null)
                    {
                        //check list having only one item.
                        head = head.Link != head ? head.Link : null;
                        last.Link = count > 1 ? head : null;
                    }
                    else
                    {
                        prev.Link = current.Link;
                    }
                    count--;
                    return true;
                }

                prev = current;
                current = current?.Link;
            } while (current != head);

            return false;
        }

        public override bool AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new Node<T>(item);
            if (current != null && IsEquals(current.Data, nodeData))
            {
                var last = GetLastNode();
                node.Link = head;
                head = node;

                last.Link = node;
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
 
        public override T GetLast()=> GetData(GetLastNode());

        public override IEnumerable<T> Get()
        {
            var current = head;
            do
            {
                if (current != null)
                {
                    yield return GetData(current);
                    current = current.Link;
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
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (array.Length - index < count)
                throw new ArgumentException(nameof(index));

            var current = head;
            do
            {
                if (current != null)
                {
                    array[index++] = GetData(current);
                    current = current.Link;
                }


            } while (current != head);
        }

        private Node<T> GetLastNode()
        {
            var current = head;
            while (current != null && current.Link != head)
                current = current.Link;

            return current;
        }
 
    }
}
