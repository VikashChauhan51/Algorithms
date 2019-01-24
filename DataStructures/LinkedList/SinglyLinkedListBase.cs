using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public abstract class SinglyLinkedListBase<T> : LinkedListBase<T>
    {
        protected Node<T> head;

        public T GetFirst() => GetData(head);
        public bool IsEmpty() => head == null && count == 0;
        protected T GetData(Node<T> node) => node != null ? node.Data : default(T);
        public virtual void Clear()
        {
            head = null;
            count = 0;
        }

    }
}
