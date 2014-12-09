namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListItem firstElement;
        private int count;

        private class ListItem
        {
            private T value;
            private ListItem nextItem;

            public ListItem(T value)
            {
                this.Value = value;
            }

            public ListItem(T value, ListItem prevNode)
            {
                this.Value = value;
                prevNode.NextItem = this;
            }

            public T Value
            {
                get
                {
                    return this.value;
                }
                set
                {
                    this.value = value;
                }
            }

            public ListItem NextItem
            {
                get
                {
                    return this.nextItem;
                }
                set
                {
                    this.nextItem = value;
                }
            }
        }

        public LinkedList()
        {
            this.firstElement = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T item)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem(item);
            }
            else
            {
                var currentElement = this.firstElement;
                while (currentElement.NextItem != null)
                {
                    currentElement = currentElement.NextItem;
                }

                currentElement.NextItem = new ListItem(item);
            }

            this.count++;
        }

        public void AddFirst(T element)
        {
            var newNode = new ListItem(element);
            newNode.NextItem = this.firstElement;
            this.firstElement = newNode;
            count++;
        }

        public void RemoveFirst()
        {
            this.firstElement = this.firstElement.NextItem;
            count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = this.firstElement; current != null; current = current.NextItem)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
