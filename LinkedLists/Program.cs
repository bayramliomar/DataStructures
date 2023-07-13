using System.Diagnostics;

namespace LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LinkedList
            //LinkedList<int> linkedList = new LinkedList<int>();
            //linkedList.AddFirst(4);
            //linkedList.AddFirst(new LinkedListNode<int>(7));
            //Console.WriteLine(linkedList.First.Value);
            //Console.WriteLine(linkedList.Last.Value);
            //Console.WriteLine(linkedList.Count);
            //var node = linkedList.Find(4);
            //if (node is not null)
            //{
            //    var newNode = linkedList.AddAfter(node, 3);
            //    linkedList.AddBefore(newNode, 8);
            //}
            //linkedList.AddLast(19);
            //linkedList.Remove(19);
            //linkedList.Clear();
            //Debug.Assert(false, "LinkedList must be empty when this method is called!");
            #endregion
            #region Custom LinkedList
            DoublyLinkedList<int> nodes = new DoublyLinkedList<int>();
            nodes.AddFirst(new Node<int>(1));
            nodes.AddFirst(new Node<int>(11));
            nodes.AddFirst(new Node<int>(15));
            nodes.Find(1);
            nodes.AddLast(10);
            #endregion
            Console.ReadLine();
        }
    }
}