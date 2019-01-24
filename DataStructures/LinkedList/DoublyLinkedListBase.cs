using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public abstract class DoublyLinkedListBase<T> : LinkedListBase<T>
    {
        protected DoublyNode<T> head;
        public T GetFirst() => GetData(head);
        public bool IsEmpty() => head == null && count == 0;
        protected T GetData(DoublyNode<T> node) => node != null ? node.Data : default(T);
        public virtual void Clear()
        {
            head = null;
            count = 0;
        }
    }
}
