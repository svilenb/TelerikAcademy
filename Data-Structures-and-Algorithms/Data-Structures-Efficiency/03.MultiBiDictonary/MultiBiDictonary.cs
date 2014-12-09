namespace _03.MultiBiDictonary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class MultiBiDictonary<K1, K2, V>
    {
        private MultiDictionary<K1, V> first;

        private MultiDictionary<K2, V> second;

        private MultiDictionary<Tuple<K1, K2>, V> both;

        public MultiBiDictonary(bool allowDuplicates)
        {
            this.first = new MultiDictionary<K1, V>(allowDuplicates);
            this.second = new MultiDictionary<K2, V>(allowDuplicates);
            this.both = new MultiDictionary<Tuple<K1, K2>, V>(allowDuplicates);
        }

        public void Add(K1 firstKey, K2 secondKey, V value)
        {
            var keys = new Tuple<K1, K2>(firstKey, secondKey);
            this.first.Add(keys.Item1, value);
            this.second.Add(keys.Item2, value);
            this.both.Add(keys, value);
        }

        public List<V> FindBothKeys(K1 firstKey, K2 secondKey)
        {
            var keys = new Tuple<K1, K2>(firstKey, secondKey);
            return this.both[keys].ToList<V>();
        }

        public List<V> FindFirstKey(K1 firstKey)
        {
            return this.first[firstKey].ToList<V>();
        }

        public List<V> FindSecondKey(K2 secondKey)
        {
            return this.second[secondKey].ToList<V>();
        }
    }
}
