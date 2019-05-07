using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class List : IEnumerable<Node>
    {
        public Node head;
        public Node currNode;

        /// <summary>
        /// Initializes a new instance of the List.
        /// </summary>
        public List()
        {
            this.head = null;
            this.currNode = null;
        }

        /// <summary>
        /// Adds an object to the end of the List.
        /// </summary>
        /// <param name="The data of node"></param>
        public void Add(int nodeData)
        {
            Node node = new Node(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.currNode.next = node;
            }

            this.currNode = node;
        }

        /// <summary>
        /// Prints the elements of the List.
        /// </summary>
        public void Print()
        {
            Node temp = head;
            while(temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the List.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the List.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Class that enumerates the elements of a List.
        /// </summary>
        public class ListEnumerator : IEnumerator<Node>
        {
            private List list;

            public ListEnumerator(List paramList)
            {
                list = new List();
                this.list.head = paramList.head;
            }

            /// <summary>
            /// Gets the element at the current position of the enumerator.
            /// </summary>
            public Node Current
            {
                get
                {
                    return this.list.currNode;
                }
            }

            /// <summary>
            /// Gets the element at the current position of the enumerator.
            /// </summary>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Releases all resources.
            /// </summary>
            public void Dispose()
            {
                this.list = null;
            }

            /// <summary>
            /// Advances the enumerator to the next element of the List.
            /// </summary>
            /// <returns>
            ///          True if the enumerator was successfully advanced to the next element; false if
            ///           the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                if (this.list.currNode == null)
                {
                    this.list.currNode = this.list.head;
                    if (this.list.currNode != null)
                        return true;
                }
                else
                {
                    if (list.currNode.next != null)
                    {
                        this.list.currNode = list.currNode.next;
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                this.list.currNode = this.list.head;
            }
        }
    }
}
