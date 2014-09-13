namespace FindWordsInFile
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Trie<TKey, TValue> : ITrie<TKey, TValue> where TValue : new()
    {
        private int count;

        private List<IEnumerable<TKey>> keys;

        private List<TValue> values;

        private Node<TKey, TValue> root;

        public Trie()
        {
            this.root = new Node<TKey, TValue>();
            this.keys = new List<IEnumerable<TKey>>();
            this.values = new List<TValue>();
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public ICollection<IEnumerable<TKey>> Keys
        {
            get
            {
                return this.keys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                return this.values;
            }
        }

        public TValue this[IEnumerable<TKey> keys]
        {
            get
            {
                if (null == keys)
                {
                    throw new ArgumentNullException("keys cannot be null.");
                }

                Node<TKey, TValue> node = this.FindNode(this.root, keys);
                if (null != node)
                {
                    if (null != node.Value)
                    {
                        return node.Value;
                    }
                }

                throw new KeyNotFoundException();
            }

            set
            {
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException();
                }
                else
                {
                    Node<TKey, TValue> node = this.FindNode(this.root, keys);
                    if (null != node)
                    {
                        node.Value = value;
                    }
                }
            }
        }

        public void Add(KeyValuePair<IEnumerable<TKey>, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            if (false == this.IsReadOnly)
            {
                this.keys.Clear();
                this.values.Clear();
                this.root = new Node<TKey, TValue>();
                this.count = 0;
            }
            else
            {
                throw new NotSupportedException("IDictionary is read only.");
            }
        }

        public bool Contains(KeyValuePair<IEnumerable<TKey>, TValue> item)
        {
            return this.Contains(item.Key);
        }

        public void CopyTo(KeyValuePair<IEnumerable<TKey>, TValue>[] array, int arrayIndex)
        {
            if (null == array)
            {
                throw new ArgumentNullException("array cannot be null.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex cannot be less than 0.");
            }
            else if (arrayIndex + this.Count > array.Count())
            {
                throw new ArgumentException("The number of elements is greater than the available space from arrayIndex to the end of the destination array.");
            }

            int currentIndex = arrayIndex;
            foreach (KeyValuePair<IEnumerable<TKey>, TValue> entry in this)
            {
                array[currentIndex] = entry;
                currentIndex++;
            }
        }

        public bool Remove(KeyValuePair<IEnumerable<TKey>, TValue> item)
        {
            return this.Remove(item.Key);
        }

        public void Add(IEnumerable<TKey> keys, TValue value)
        {
            this.Add(this.root, keys, value);
        }

        public bool ContainsKey(IEnumerable<TKey> keys)
        {
            Node<TKey, TValue> node = this.FindNode(keys);
            return node != null && node.Value != null;
        }

        public bool Remove(IEnumerable<TKey> keys)
        {
            if (null == keys)
            {
                throw new ArgumentNullException();
            }
            else if (this.IsReadOnly)
            {
                throw new NotSupportedException();
            }

            Node<TKey, TValue> node = this.FindNode(keys);
            if (null == node)
            {
                return false;
            }

            if (null == node.Parent)
            {
                return false;
            }

            bool result = node.Parent.Remove(node.Key);

            this.Prune();
            return result;
        }

        public bool TryGetValue(IEnumerable<TKey> keys, out TValue value)
        {
            Node<TKey, TValue> node = this.FindNode(keys);
            if (null == node)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                if (null != node.Value)
                {
                    value = node.Value;
                    return true;
                }
                else
                {
                    value = default(TValue);
                    return false;
                }
            }
        }

        public ICollection<KeyValuePair<IEnumerable<TKey>, TValue>> Suffixes(IEnumerable<TKey> keys)
        {
            if (null == keys)
            {
                throw new ArgumentNullException();
            }

            ICollection<KeyValuePair<IEnumerable<TKey>, TValue>> result = new List<KeyValuePair<IEnumerable<TKey>, TValue>>();
            if (0 == keys.Count())
            {
                return result;
            }

            Node<TKey, TValue> node = this.FindNode(this.root, keys);
            if (null == node)
            {
                return result;
            }

            TrieEnumerator enumerator = new TrieEnumerator(node);
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            return result;
        }

        public IEnumerator<KeyValuePair<IEnumerable<TKey>, TValue>> GetEnumerator()
        {
            return new TrieEnumerator(this.root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool Contains(IEnumerable<TKey> keys)
        {
            Node<TKey, TValue> node = this.FindNode(keys);
            if (null == node)
            {
                return false;
            }
            else
            {
                return null != node.Value;
            }
        }

        private void Add(Node<TKey, TValue> node, IEnumerable<TKey> keys, TValue value)
        {
            if (null == node)
            {
                throw new ArgumentNullException("node cannot be null.");
            }
            else if (null == keys)
            {
                throw new ArgumentNullException("node cannot be null.");
            }
            else if (null == value)
            {
                throw new ArgumentNullException("value cannot be null.");
            }

            TKey key = keys.FirstOrDefault();
            if (null == key)
            {
                throw new ArgumentNullException("key cannot be null.");
            }

            Node<TKey, TValue> childNode = node.Children.Where(child => child.Key.Equals(key)).FirstOrDefault();
            if (null != childNode)
            {
                this.Add(childNode, keys.Skip(1), value);
            }
            else
            {
                Node<TKey, TValue> newNode;
                int keysCount = keys.Count();
                if (1 == keysCount)
                {
                    newNode = new Node<TKey, TValue>(key, value);
                    node.Add(newNode);
                    this.count++;
                    this.keys.Add(keys);
                    this.values.Add(value);
                }
                else if (0 == keysCount)
                {
                    if (null != node.Value)
                    {
                        throw new InvalidOperationException("Duplicate Key!");
                    }
                    else
                    {
                        node.Value = value;
                    }
                }
                else
                {
                    newNode = new Node<TKey, TValue>(key);
                    node.Add(newNode);
                    this.Add(newNode, keys.Skip(1), value);
                }
            }
        }

        private Node<TKey, TValue> FindNode(IEnumerable<TKey> keys)
        {
            return this.FindNode(this.root, keys);
        }

        private Node<TKey, TValue> FindNode(Node<TKey, TValue> node, IEnumerable<TKey> keys)
        {
            if (null == node)
            {
                throw new ArgumentNullException("node may not be null.");
            }
            else if (null == keys)
            {
                throw new ArgumentNullException("keys may not be null.");
            }

            TKey key = keys.FirstOrDefault();
            if (null == key)
            {
                throw new ArgumentNullException("keys may not be empty.");
            }
            else
            {
                IEnumerable<Node<TKey, TValue>> children = node.Children.Where(child => child.Key.Equals(key));

                if (1 < children.Count())
                {
                    throw new InvalidOperationException(
                        string.Format("The trie has more than one children with a specified key {0}", key.ToString()));
                }
                else if (0 == children.Count())
                {
                    return null;
                }
                else
                {
                    Node<TKey, TValue> child = children.Single();

                    if (1 == keys.Count())
                    {
                        return child;
                    }
                    else
                    {
                        if (keys.Count() >= 2)
                        {
                            return this.FindNode(child, keys.Skip(1));
                        }
                        else
                        {
                            throw new InvalidOperationException("Not enough keys to complete lookup.");
                        }
                    }
                }
            }
        }

        private void Prune()
        {
            this.Prune(this.root);
        }

        private void Prune(Node<TKey, TValue> node)
        {
            if (node.Children.Count() == 0 && null == node.Value)
            {
                node.Parent.Remove(node.Key);
            }
            else
            {
                foreach (Node<TKey, TValue> child in node.Children)
                {
                    this.Prune(child);
                }
            }
        }

        private class TrieEnumerator : IEnumerator<KeyValuePair<IEnumerable<TKey>, TValue>>
        {
            private Node<TKey, TValue> node;

            private Queue<KeyValuePair<IEnumerable<TKey>, TValue>> elements;

            public TrieEnumerator(Node<TKey, TValue> node)
            {
                this.node = node;
            }

            public KeyValuePair<IEnumerable<TKey>, TValue> Current
            {
                get
                {
                    if (null == this.elements)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.elements.Peek();
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
                return;
            }

            public bool MoveNext()
            {
                if (null == this.elements)
                {
                    this.Reset();
                }
                else if (this.elements.Count == 0)
                {
                    return false;
                }
                else
                {
                    this.elements.Dequeue();
                }

                if (this.elements.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void Reset()
            {
                this.elements = new Queue<KeyValuePair<IEnumerable<TKey>, TValue>>();
                this.InorderTraversal(this.node);
            }

            private void InorderTraversal(Node<TKey, TValue> node)
            {
                if (null != node.Value)
                {
                    this.elements.Enqueue(new KeyValuePair<IEnumerable<TKey>, TValue>(node.Keys, node.Value));
                }

                foreach (Node<TKey, TValue> child in node.Children)
                {
                    this.InorderTraversal(child);
                }
            }
        }

        private class Node<K, V> where V : new()
        {
            private SortedList<K, Node<K, V>> children;

            public Node()
            {
                this.Key = default(K);
                this.children = new SortedList<K, Node<K, V>>();
            }

            public Node(K key)
            {
                this.Key = key;
                this.children = new SortedList<K, Node<K, V>>();
            }

            public Node(K key, V value)
            {
                this.Key = key;
                this.Value = value;
                this.children = new SortedList<K, Node<K, V>>();
            }

            public K Key
            {
                get;
                set;
            }

            public V Value
            {
                get;
                set;
            }

            public List<Node<K, V>> Children
            {
                get
                {
                    return this.children.Select(child => child.Value).ToList();
                }
            }

            public Node<K, V> Parent
            {
                get;
                private set;
            }

            public IEnumerable<K> Keys
            {
                get
                {
                    if (null != this.Parent)
                    {
                        List<K> result = new List<K>(this.Parent.Keys);
                        result.Add(this.Key);
                        return result;
                    }
                    else
                    {
                        return new List<K>() { this.Key };
                    }
                }
            }

            public void Add(Node<K, V> node)
            {
                this.children.Add(node.Key, node);
                node.Parent = this;
            }

            public bool Remove(K key)
            {
                return this.children.Remove(key);
            }
        }
    }
}
