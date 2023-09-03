using _253504_dmi_Lab5.Interfaces;
using System;
using System.Reflection;
using System.Threading;

namespace _253504_dmi_Lab5.Collections
{
    class MyCustomCollection<T> : ICustomCollectioin<T>
    {
        private int counter = 0;
        private Node<T>? head = null;
        private Node<T>? current = null;

        
        public MyCustomCollection() {}

        private bool CorrectIndexCheck(int index) => index >= 0 && index < counter;



        public bool IsEmty()
        {
            return counter == 0;
        }
        public T this[int index]
        {
            get
            {
                if (CorrectIndexCheck(index))
                {
                    Node<T>? currentNode = head;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode?.Next;
                    }

                    if (currentNode != null)
                    {
                        return currentNode.Value;
                    }
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (CorrectIndexCheck(index))
                {
                    Node<T>? currentNode = head;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode?.Next;
                    }

                    if (currentNode != null)
                    {
                        currentNode.Value = value;
                        return;
                    }
                }

                throw new IndexOutOfRangeException();
            }
        }

        public void Reset()
        {
            current = head;
        }

        public void Next()
        {
            if (current != null)
            {
                current = current.Next;
            }
        }

        public T Current()
        {
            if (current != null)
            {
                return current.Value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int Count { get => counter; }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (head == null)
            {
                head = newNode;
                current = newNode;
            }
            else
            {
                Node<T>? currentNode = head;
                while (currentNode?.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }

            counter++;
        }

        public void Remove(T item)
        {
            if (head == null)
                return;

            if (EqualityComparer<T>.Default.Equals(current.Value, item))
                current = null;

            if (EqualityComparer<T>.Default.Equals(head.Value, item))
            {
                head = head.Next;
                counter--;
            }

            Node<T> ? currentNode = head;
            while (currentNode?.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, item))
                { 
                    currentNode.Next = currentNode.Next.Next;
                    counter--;
                }
            }
        }

        public T RemoveCurrent()
        {
            T tmp = current.Value;
            if (current != null)
            {
                if (current == head)
                    head = current.Next;

                Node<T>? currentNode = head;
                while (currentNode?.Next != current)
                {
                    currentNode = currentNode.Next;
                }

                if (currentNode != null)
                {
                    currentNode.Next = current.Next;
                    current = null;
                }
            }
            --counter;
            return tmp;
        }

        public void Print()
        {
            if(head != null)
            {
                Node<T> currentNode = head;
                while(currentNode != null) 
                {
                    Console.WriteLine(currentNode.Value.ToString());
                    currentNode = currentNode.Next;
                }
            }
            

        }

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T>? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }
    }
}
