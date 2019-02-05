using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public sealed class ArrayQueue<T> : QueueBased<T>
    {
        private T[] items;
        private long count;
        public override long Count => count;
        static T[] emptyArray = new T[0];
        private const int defaultCapacity = 4;

        public ArrayQueue()
        {
            items = emptyArray;
            count = 0;
        }
        public ArrayQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var size = collection.LongCount();

            if (size > 0)
            {
                items = new T[size];

                collection.ToArray().CopyTo(items, 0);
                count = size;
            }
            else
            {
                items = new T[defaultCapacity];
                count = 0;
            }
        }

        public override void Clear()
        {
            items = null;
            items = emptyArray;
            count = 0;
        }

        public override bool Contains(T item)
        {
            if (IsValidObject(item))
            {
                var size = count;
                while (size-- > 0)
                {
                    if (item == null)
                    {
                        if (items[count] == null)
                            return true;
                    }
                    else if (items[count] != null && item.Equals(items[count]))
                        return true;
                }

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

            Array.Copy(items, 0, array, index, count);
        }

        public override T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException("Empty");

            T item = items[0];
            items[0] = default(T);
            count--;
            return item;
        }

        public override void Enqueue(T item)
        {
            if (count == items.Length)
            {
                T[] newArray = new T[(items.Length == 0) ? defaultCapacity : 2 * items.Length];
                Array.Copy(items, 0, newArray, 0, count);
                items = newArray;
            }

            items[count++] = item;
        }

        public override IEnumerable<T> Get()
        {
            for (int i = 0; i < count; i++)
                yield return items[i];
        }

        public override T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Empty");

            return items[0];
        }

        public override T[] ToArray()
        {
            T[] objArray = new T[count];
            int i = 0;
            while (i < count)
            {
                objArray[i] = items[count - i - 1];
                i++;
            }
            return objArray;
        }
    }
}
