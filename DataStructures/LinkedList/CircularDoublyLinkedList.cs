using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{

    public class CircularDoublyLinkedList<T> : DoublyLinkedListBase<T>
    {
        public CircularDoublyLinkedList()
        {

        }
        /// <summary>
        /// Instantiate with node(s).
        /// </summary>
        /// <param name="collection"> <see cref="IEnumerable{T}"/></param>
        public CircularDoublyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
                AddLast(item);

        }

        public override bool AddAfter(T nodeData, T item)
        {
            var current = head;
            do
            {
                if (current != null && IsEquals(current.Data, nodeData))
                {
                    var node = new DoublyNode<T>(item);
                    node.Next = current.Next;
                    node.Prev = current;
                    current.Next = node;
                    count++;
                    return true;
                }
                current = current?.Next;
            } while (current != head);
            return false;
        }

        public override bool AddBefore(T nodeData, T item)
        {
            var current = head;
            var node = new DoublyNode<T>(item);
            if (current != null && IsEquals(current.Data, nodeData))
            {
                node.Next = head;
                head.Prev = node;
                if (count == 1)
                {
                    node.Prev = head;
                    head.Next = node;

                }
                else
                {
                    node.Prev = head.Prev;
                    head.Prev.Next = node;
                }
                head = node;
                count++;
                return true;
            }
            else
            {
                while (current != null && current.Next != head)
                {
                    if (IsEquals(current.Next.Data, nodeData))
                    {
                        node.Next = current.Next;
                        node.Prev = current;
                        current.Next = node;
                        current.Next.Prev = node;
                        count++;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        public override void AddFirst(T item)
        {
            //create node.
            var node = new DoublyNode<T>(item);

            //Add first node.
            if (head == null)
            {
                head = node;
                head.Next = head;
                head.Prev = head;
            }
            else
            {

                if (count == 1)
                {
                    node.Prev = head;
                    node.Next = head;
                    head.Next = node;
                    head.Prev = node;
                }
                else
                {
                    node.Next = head;
                    head.Prev.Next = node;
                    node.Prev = head.Prev;
                    head.Prev = node;
                }
                head = node;
            }
            count++;
        }

        public override void AddLast(T item)
        {
            //create node.
            var node = new DoublyNode<T>(item);

            //Add first node.
            if (head == null)
            {
                head = node;
                head.Next = head;
                head.Prev = head;
            }
            else
            {
                if (count == 1)
                {
                    head.Next = node;
                    head.Prev = node;
                    node.Next = head;
                    node.Prev = head;

                }
                else
                {
                    node.Next = head;
                    node.Prev = head.Prev;
                    head.Prev.Next = node;
                    head.Prev = node;

                }

            }
            count++;
        }

        public override bool Contains(T item)
        {
            var current = head;
            do
            {
                if (current != null && IsEquals(current.Data, item))
                    return true;

                current = current?.Next;

            } while (current != head);

            return false;
        }

        public override void CopyTo(T[] array, int index)
        {
            var current = head;
            do
            {
                if (current != null)
                {
                    array[index++] = GetData(current);
                    current = current.Next;
                }

            } while (current != head);
        }

        public override IEnumerable<T> Get()
        {
            var current = head;
            do
            {
                if (current != null)
                {
                    yield return GetData(current);
                    current = current.Next;
                }

            } while (current != head);
        }

        public override T GetLast() => GetData(GetLastNode());

        public override bool Remove(T item)
        {
            var current = head;
            do
            {
                if (current != null && (IsEquals(current.Data, item)))
                {
                    if (count == 1)
                    {
                        head = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        if (current == head)
                            head = current.Next;
                        else
                            current = current.Next;
                    }
                    count--;
                    return true;
                }
                current = current?.Next;
            } while (current != head);

            return false;
        }

        public override bool RemoveFirst()
        {
            if (head == null || count == 0)
                return false;

            if (count==1)
            {
                head = null;
            }
            else
            {
                var last = head.Prev;
                head = head.Next;
                head.Prev = last;
                last.Next = head;

            }
            count--;
            return true;
        }

        public override bool RemoveLast()
        {
            if (head == null || count == 0)
                return false;

            if (count==1)
            {
                head = null;
            }
            else
            {
               var last = head.Prev.Prev;
                last.Next = head;
                head.Prev = last;

            }
            count--;
            return true;
        }

        private DoublyNode<T> GetLastNode()
        {
            return head == null || count == 1 ? head : head.Prev;
        }
    }
}
