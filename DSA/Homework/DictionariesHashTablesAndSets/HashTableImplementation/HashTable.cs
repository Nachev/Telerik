namespace HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*Implement the data structure "hash table" in a class 
    HashTable<K,T>. Keep the data in array of lists of keyvalue pairs (LinkedList<KeyValuePair<K,T>>[]) with 
    initial capacity of 16. When the hash table load runs 
    over 75%, perform resizing to 2 times larger capacity. 
    Implement the following methods and properties: 
    Add(key, value), Find(key)value, Remove( 
    key), Count, Clear(), this[], Keys. Try to make 
    the hash table to support iterating over its elements 
    with foreach.*/
    public class HashTable<K, T> : ICollection<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;

        private LinkedList<KeyValuePair<K, T>>[] container;
        private int counter;

        public HashTable()
        {
            this.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Add(K key, T value)
        {
            var keyValue = new KeyValuePair<K, T>(key, value);
            this.Add(keyValue);
        }

        public void Add(KeyValuePair<K, T> item)
        {
            CheckForNullItem("add", item);

            int containerLength = this.container.Length;
            int index = GetIndexByHash(item.Key, containerLength);
            this.container[index].AddLast(item);
            this.counter++;

            if (this.counter > containerLength * 0.75)
            {
                Grow(containerLength);
            }
        }
 
        private int GetIndexByHash(K key, int containerLength)
        {
            var hash = key.GetHashCode();
            hash = hash < 0 ? hash * -1 : hash; // ensure positive
            int index = hash % containerLength;
            return index;
        }
 
        private void Grow(int containerLength)
        {
            var newArray = new LinkedList<KeyValuePair<K, T>>[containerLength * 2];
            Array.Copy(this.container, newArray, containerLength);
            this.container = newArray;
        }

        public void Clear()
        {
            this.counter = 0;
            this.container = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
        }

        public void CopyTo(KeyValuePair<K, T>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("Destination array cannot be null.");
            }

            if (array.Length < this.container.Length)
            {
                throw new ArgumentException("Destination array capacity is insufficent.");
            }

            Array.Copy(this.container, array, this.container.Length);
        }

        public bool Remove(KeyValuePair<K, T> item)
        {
            CheckForNullItem("remove", item);
            throw new NotImplementedException();
            this.counter--;
        }

        public int Count
        {
            get
            {
                return this.counter;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T Find(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Cannot search for null key.");
            }

            var index = GetIndexByHash(key, this.container.Length);
            var cell = this.container[index];
            var firstNode = cell.First;
            while (firstNode != cell.Last)
            {
                if (firstNode.Value.Key.Equals(key))
                {
                    return firstNode.Value.Value;
                }

                firstNode = firstNode.Next;
            }

            throw new KeyNotFoundException("No such key found: " + key);
        }

        public bool Contains(KeyValuePair<K, T> item)
        {
            CheckForNullItem("search", item);
            var index = GetIndexByHash(item.Key, this.container.Length);
            var cell = this.container[index];
            var listNode = cell.First;
            while (listNode != cell.Last)
            {
                if (listNode.Value.Key.Equals(item.Key))
                {
                    return true;
                }

                listNode = listNode.Next;
            }

            return false;
        }

        IEnumerator<KeyValuePair<K, T>> IEnumerable<KeyValuePair<K, T>>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            int innerCounter = 0;
            int index = 0;
            do
            {
                var cell = this.container[index];
                var listNode = cell.First;
                while (listNode != cell.Last.Next)
                {
                    yield return listNode.Value;
                    innerCounter++;
                    listNode = listNode.Next;
                }

                index++;
            }
            while (innerCounter < this.counter);
        }

        private void CheckForNullItem(string method, KeyValuePair<K, T> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("Cannot {0} null key to HashTable.", method);
            }

            if (item.Value == null)
            {
                throw new ArgumentNullException("Cannot {0} null value to HashTable.", method);
            }
        }
    }
}