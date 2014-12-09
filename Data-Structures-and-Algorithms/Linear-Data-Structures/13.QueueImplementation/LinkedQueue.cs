namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> elements;

        public LinkedQueue()
        {
            this.elements = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enqueue(T value)
        {
            this.elements.AddLast(value);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot extract value from empty queue!");
            }

            return this.elements.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot extract value from empty queue!");
            }

            T value = this.elements.First.Value;

            this.elements.RemoveFirst();

            return value;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
