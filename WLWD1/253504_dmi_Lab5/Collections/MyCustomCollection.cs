using _253504_dmi_Lab5.Interfaces;
using System.Collections;
using _253504_dmi_Lab5.Entities;

namespace _253504_dmi_Lab5.Collections
{
    class MyCustomCollection<T> : ICustomCollectioin<T>, IEnumerable<T>
    {
        private int counter = 0;
        private Node<T>? head = null;
        protected Node<T>? current = null;

<<<<<<< HEAD
        public IEnumerator<T> GetEnumerator()
        {
            return new MyCustomCollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private bool CorrectIndexCheck(int index) => index >= 0 && index < counter;
        public MyCustomCollection() { }
        public bool IsEmpty()
=======
        
        public MyCustomCollection() {}

        private bool CorrectIndexCheck(int index) => index >= 0 && index < counter;



        public bool IsEmty()
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
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

        public bool MoveNext()
        {
            if (current != null)
            {
                if (current.Next != null)
                {
                    current = current.Next;
                    return true;
                }
                else return false;


            }
            else
            {
                current = head;
                return true;
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
                throw new CustomException("Removal is not possible. Structure is empty");

            if (EqualityComparer<T>.Default.Equals(current.Value, item))
                current = null;

            if (EqualityComparer<T>.Default.Equals(head.Value, item))
            {
                head = head.Next;
                counter--;
            }

            Node<T>? currentNode = head;
            while (currentNode?.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, item))
                {
                    currentNode.Next = currentNode.Next.Next;
                    counter--;
                    return;
                }
                currentNode = currentNode.Next;
            }
            throw new CustomException();
        }

        public void RemoveCurrent()
        {
            if (current != null && head != null)
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
                    currentNode.Next = currentNode.Next.Next;
                    current = null;
                }
            }
<<<<<<< HEAD
=======
            --counter;
            return tmp;
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
        }

        public override string ToString()
        {
            if (head != null)
            {
                Node<T> currentNode = head;
                string str = string.Empty;
                while (currentNode != null)
                {
<<<<<<< HEAD
                    str += currentNode.Value.ToString() + '\n';
=======
                    Console.WriteLine(currentNode.Value.ToString());
>>>>>>> 998b300a56fd235981e77e55e377011b3eb39bf8
                    currentNode = currentNode.Next;
                }
                return str;
            }

            else return "The structure is empty";
        }

        protected class Node<T>
        {
            public T Value { get; set; }
            public Node<T>? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private class MyCustomCollectionEnumerator : IEnumerator<T>
        {
            private MyCustomCollection<T> collection;

            public MyCustomCollectionEnumerator(MyCustomCollection<T> collection)
            {
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    if (collection.current != null)
                    {
                        return collection.current.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object? IEnumerator.Current => Current;

            public bool MoveNext()
            {
                return collection.MoveNext();
            }

            public void Reset()
            {
                collection.Reset();
            }

            public void Dispose()
            {
            }

        }
    }
}
