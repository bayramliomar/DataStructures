using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedLists
{
    public class DoublyLinkedList<T> : IEnumerable<Node<T>>
    {
        public Node<T>? Head { get; set; }
        public int Count { get; set; }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T>? currentNode = Head;
            while (currentNode is not null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //1 11 19 22
        public Node<T> AddFirst(T value)
        {
            var newNode=new Node<T>(value);
            if(Head is null)
            {
                InternalInsertNodeToEmptyList(newNode);
            }
            else
            {
                InternalInsertNodeBefore(newNode);
                Head = newNode;
            }
            Count++;
            return newNode;
        }

        public void AddFirst(Node<T> node)
        {
            if (Head is null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(node);
                Head = node;
            }
            Count++;
        }
        //1,19,21,
        //21<=10=>1
        public Node<T> AddLast(T value)
        {
            var newNode = new Node<T>(value);
            if (Head is null)
            {
                InternalInsertNodeToEmptyList(newNode);
            }
            else
            {
                InternalInsertNodeBefore(newNode);
            }
            Count++;
            return newNode;
        }

        public Node<T>? Find(T value)
        {
            var currentNode = Head;
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            if (currentNode is not null)
            {
                if (value is not null)
                {
                    do
                    {
                        if (equalityComparer.Equals(currentNode!.Value, value))
                        {
                            return currentNode;
                        }
                        currentNode = currentNode.Next;

                    } while (currentNode != Head);
                }
            }
            return default;
        }

        public bool Remove(T value)
        {
            Node<T>? node = Find(value);
            if(node is not null)
            {
                var next=node.Next; 
                var prev=node.Prev; 

                if(prev is not null)
                {
                    prev.Next = next;
                }
                if (next is not null)
                {
                    next.Prev = prev;
                }
                Count--;

                return true;
            }
            return false;
        }

        private void InternalInsertNodeBefore(Node<T> newNode)
        {
            newNode.Next = Head;
            newNode.Prev = Head.Prev;
            Head.Prev!.Next = newNode;
            Head.Prev = newNode;
        }
        private void InternalInsertNodeToEmptyList(Node<T> newNode)
        {
            newNode.Next = newNode;
            newNode.Prev = newNode;
            Head = newNode;
        }
    }
}
