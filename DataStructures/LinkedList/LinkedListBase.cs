using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public abstract class LinkedListBase<T>
    {
        protected long count;

        public abstract T GetLast();
        public abstract void AddFirst(T item);
        public abstract void AddLast(T item);
        public abstract bool AddBefore(T nodeData, T item);
        public abstract bool AddAfter(T nodeData, T item);
        public abstract bool RemoveLast();
        public abstract bool RemoveFirst();
        public abstract bool Remove(T item);
        public abstract IEnumerable<T> Get();
        public abstract bool Contains(T item);
        public abstract void CopyTo(T[] array, int index);

        protected bool IsEquals(T source, T item) => (source == null && item == null) || source.Equals(item);

        public long Count() => count;
    }
}
