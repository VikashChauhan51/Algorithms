using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public abstract class StackBase<T>
    {
        
        public abstract long Count { get; }
        public abstract void Push(T item);
        public abstract T Pop();
        public abstract T Peek();
        public abstract void Clear();
        public abstract IEnumerable<T> Get();
        public abstract bool Contains(T item);
        public abstract void CopyTo(T[] array, int index);
        public abstract T[] ToArray();

        protected bool IsValidObject(T item) => (item is T) || (item == null && default(T) == null);
    }
}
