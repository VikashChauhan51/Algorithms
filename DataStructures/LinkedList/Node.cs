using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public sealed class Node<T>
    {
        public Node(T data)
        {
            this.Data = data;
        }
        public T Data { get; set; }
        public Node<T> Link { get; set; }
    }
}
