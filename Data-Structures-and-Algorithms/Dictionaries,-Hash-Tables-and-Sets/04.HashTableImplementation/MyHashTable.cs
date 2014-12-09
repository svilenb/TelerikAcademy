namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyHashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private LinkedList<KeyValuePair<K, V>>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        public MyHashTable()
            : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR)
        {
        }

        public MyHashTable(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new LinkedList<KeyValuePair<K, V>>[capacity];
            this.loadFactor = loadFactor;
            this.threshold = (int)(capacity * this.loadFactor);
        }

        public V this[K key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        private LinkedList<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF;
            index = index % this.table.Length;
            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new LinkedList<KeyValuePair<K, V>>();
            }

            return this.table[index] as LinkedList<KeyValuePair<K, V>>;
        }

        public V Get(K key)
        {
            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                foreach (KeyValuePair<K, V> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(V);
        }

        public V Set(K key, V value)
        {
            if (this.size >= this.threshold)
            {
                this.Expand();
            }

            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, true);
            bool found = false;
            KeyValuePair<K, V> oldEntry = new KeyValuePair<K, V>();
            foreach (var item in chain)
            {
                if (item.Key.Equals(key))
                {
                    oldEntry = item;
                    found = true;
                }
            }

            if (found)
            {
                KeyValuePair<K, V> newEntry = new KeyValuePair<K, V>(key, value);
                var result = oldEntry.Value;
                chain.Remove(oldEntry);
                chain.AddLast(newEntry);
                return result;
            }

            chain.AddLast(new KeyValuePair<K, V>(key, value));
            this.size++;

            return default(V);
        }

        public bool Remove(K key)
        {
            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                bool found = false;
                KeyValuePair<K, V> nodeToRemove = new KeyValuePair<K, V>();
                foreach (var item in chain)
                {
                    if (item.Key.Equals(key))
                    {
                        nodeToRemove = item;
                        found = true;
                    }
                }

                if (found)
                {
                    chain.Remove(nodeToRemove);
                    this.size--;
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.table = new LinkedList<KeyValuePair<K, V>>[this.initialCapacity];
            this.size = 0;
        }

        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            LinkedList<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new LinkedList<KeyValuePair<K, V>>[newCapacity];

            this.threshold = (int)(newCapacity * this.loadFactor);
            foreach (LinkedList<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, V> keyValuePair in oldChain)
                    {
                        LinkedList<KeyValuePair<K, V>> chain = FindChain(keyValuePair.Key, true);
                        chain.AddLast(keyValuePair);
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<K, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}
