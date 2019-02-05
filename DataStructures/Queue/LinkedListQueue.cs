using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public sealed class LinkedListQueue<T> : QueueBased<T>
    {
        private CircularDoublyLinkedList<T> items;

        public override long Count => items.Count();

        public LinkedListQueue()
        {
            items = new CircularDoublyLinkedList<T>();
        }
        public LinkedListQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            items = new CircularDoublyLinkedList<T>(collection);
        }

        public override void Clear()
        {
            items.Clear();
            items = new CircularDoublyLinkedList<T>();
        }

        public override bool Contains(T item) => IsValidObject(item) && items.Contains(item);

        public override void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (array.Length - index < items.Count())
                throw new ArgumentException(nameof(index));

            items.CopyTo(array, index);
        }

        public override T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Empty");

            var item = items.GetFirst();
            items.RemoveFirst();
            return item;
        }

        public override void Enqueue(T item)
        {
            if (!IsValidObject(item))
                throw new ArgumentException(nameof(item));

            items.AddLast(item);
        }

        public override IEnumerable<T> Get() => items.Get();

        public override T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Empty");

            return items.GetFirst();
        }

        public override T[] ToArray()
        {
            var count = items.Count();
            T[] objArray = new T[count];
            if (count > 0)
                items.CopyTo(objArray, 0);

            return objArray;
        }
    }
}
