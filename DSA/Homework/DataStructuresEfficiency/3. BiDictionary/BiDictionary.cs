namespace _3.BiDictionary
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> valuesByKey1;
        private MultiDictionary<K2, T> valuesByKey2;

        public BiDictionary(bool allowDuplicates)
        {
            this.valuesByKey1 = new MultiDictionary<K1, T>(allowDuplicates);
            this.valuesByKey2 = new MultiDictionary<K2, T>(allowDuplicates);
        }

        public void AddByKey1(K1 key, T value)
        {
            this.valuesByKey1.Add(key, value);
        }

        public void AddByKey2(K2 key, T value)
        {
            this.valuesByKey2.Add(key, value);
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            this.valuesByKey1.Add(key1, value);
            this.valuesByKey2.Add(key2, value);
        }

        public ICollection<T> FindByKey1(K1 key)
        {
            return this.valuesByKey1[key];
        }

        public ICollection<T> FindByKey2(K2 key)
        {
            return this.valuesByKey2[key];
        }

        public ICollection<T> FindByKeys(K1 key1, K2 key2)
        {
            ICollection<T> valuesByKey1 = this.valuesByKey1[key1];
            ICollection<T> valuesByKey2 = this.valuesByKey2[key2];
            return valuesByKey1.Intersect(valuesByKey2).ToList();
        }
    }
}
