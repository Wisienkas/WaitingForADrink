using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitingForADrink
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Queue<T>
    {
        Node<T> first = null;
        Node<T> last = null;

        public Queue()
        {

        }

        public void add(T v)
        {
            if(first == null)
            {
                first = new Node<T>(v);
                last = first;
            }
            else
            {
                Node<T> node = new Node<T>(v);
                last.Next = node;
                last = node;
            }

        }

        public bool isEmpty()
        {
            return first == null;
        }

        class Node<T>
        {
            private T v;

            public T Value { get; }
            public Node<T> Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        public T poll()
        {
            if (isEmpty())
                throw new InvalidOperationException();

            Node<T> first = this.first;
            this.first = this.first.Next;
            return first.Value;
        }
    }
}
