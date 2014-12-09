namespace _05.HashedSetImplementation
{
    using System;
    using System.Collections.Generic;

    using _04.HashTableImplementation;

    class MyHashedSet<T> : IEnumerable<T>
    {
        private MyHashTable<T, bool> elements;

        public MyHashedSet()
        {
            this.elements = new MyHashTable<T, bool>();
        }

        public MyHashedSet(MyHashedSet<T> hashedSet)
            : this()
        {
            foreach (var element in hashedSet)
            {
                this.elements.Set(element, true);
            }
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public void Add(T element)
        {
            this.elements.Set(element, true);
        }

        public bool Contains(T element)
        {
            return this.elements.Get(element);
        }

        public bool Remove(T element)
        {
            return this.elements.Remove(element);
        }

        public void UnionWith(MyHashedSet<T> other)
        {
            foreach (var element in other)
            {
                if (!this.Contains(element))
                {
                    this.Add(element);
                }
            }
        }

        public void IntersectWith(MyHashedSet<T> other)
        {
            var resultTable = new MyHashTable<T, bool>();
            foreach (var element in other)
            {
                if (this.Contains(element))
                {
                    resultTable.Set(element, true);
                }
            }

            this.elements = resultTable;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element.Key;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
