using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            this.Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Prev { get; set; }
    }
}
