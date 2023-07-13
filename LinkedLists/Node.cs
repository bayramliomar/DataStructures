using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public sealed class Node<T>
    {
        public T Value;
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }
}
