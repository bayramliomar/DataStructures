using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueStack
{
    public class MyQueue<T>
    {
        private const int DEFAULT_SIZE = 50;
        private T[] elements;
        private int head=0;
        private int tail=-1;
        private int count=0;

        public MyQueue(int initialSize=DEFAULT_SIZE)
        {
            elements=new T[initialSize];
        }
        public void Enqueue(T item)
        {
            if (count == elements.Length)
            {
                Extend();
            }
            tail++;
            elements[tail]=item;
            count++;
        }
        public T Dequeue()
        {
            ThrowIfEmpty();
            T item=elements[head];
            elements[head++] = default;
            count--;

            if(count>0 && count == elements.Length / 4)
            {
                Shrink();
            }

            return item; 
        }

        public void ThrowIfEmpty()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        private void Extend()
        {
            /*
             Old->1,2,3 head=0,tail=2,count=3
             New->1,2,3,0,0,0 head=0,tail=2,count=3
             */
            Array.Resize(ref elements, elements.Length * 2);
            head=0;
            tail = count - 1;
        }

        private void Shrink()
        {
            /*
             Old->1,2,3,0,0,0 head=0,tail=2,count=3
             New->1,2,3 head=0,tail=2,count=3
             */
            int capacity = elements.Length / 2;
            var newElements=new T[capacity];
            Array.Copy(elements,head, newElements,0,count);
            elements = newElements;
            head = 0;
            tail = count - 1;
        }
    }
}
