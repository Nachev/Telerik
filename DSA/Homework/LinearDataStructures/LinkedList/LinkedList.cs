namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class LinkedList<T> : ILinkedList<T>
    {
        private ListItem<T> firstElement;
        private int count;

        public LinkedList()
        {
            this.Count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                Debug.Assert(value >= 0, "Incorrect negative value for count.");
                this.count = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item value to add cannot be null.");
            }

            var nodeToAdd = new ListItem<T>(item);

            if (this.firstElement == null)
            {
                this.firstElement = nodeToAdd;
                this.firstElement.NextItem = this.firstElement;
            }
            else
            {
                ListItem<T> currentNode = this.firstElement;

                while (currentNode.NextItem != firstElement)
                {
                    currentNode = currentNode.NextItem;
                } 

                currentNode.NextItem = nodeToAdd;
                currentNode.NextItem.NextItem = this.firstElement;
            }

            this.Count++;
        }

        public void AddAfter(T target, T item)
        {
            if (target == null)
            {
                throw new ArgumentNullException("Item target value cannot be null.");
            }

            if (item == null)
            {
                throw new ArgumentNullException("Item value to add cannot be null.");
            }

            var nodeToAdd = new ListItem<T>(item);
            var targetNode = Find(target);
            if (targetNode == null)
            {
                if (this.firstElement == null)
                {
                    this.firstElement = nodeToAdd;
                    this.firstElement.NextItem = this.firstElement;
                }
                else
                {
                    throw new ArgumentException("Target item do not exist in this list.");
                }
            }
            else
            {
                nodeToAdd.NextItem = targetNode.NextItem;
                targetNode.NextItem = nodeToAdd;
            }

            this.Count++;
        }

        public void AddBefore(T target, T item)
        {
            if (target == null)
            {
                throw new ArgumentNullException("Item target value cannot be null.");
            }

            if (item == null)
            {
                throw new ArgumentNullException("Item value to add cannot be null.");
            }

            var nodeToAdd = new ListItem<T>(item);
            var targetNode = Find(target);
            if (targetNode == null)
            {
                if (this.firstElement == null)
                {
                    this.firstElement = nodeToAdd;
                    this.firstElement.NextItem = this.firstElement;
                }
                else
                {
                    throw new ArgumentException("Target item do not exist in this list.");
                }
            }
            else
            {
                ListItem<T> currentNode = this.firstElement;

                while (currentNode.NextItem != targetNode)
                {
                    currentNode = currentNode.NextItem;
                }

                currentNode.NextItem = nodeToAdd;
                nodeToAdd.NextItem = targetNode;
            }

            this.Count++;
        }

        public void Clear()
        {
            ListItem<T> nextNode = this.firstElement;
            while (nextNode != null)
            {
                var currentNode = nextNode;
                nextNode = nextNode.NextItem;
                currentNode.Clear();
            }

            this.Count = 0;
            this.firstElement = null;
        }

        public bool Contains(T item)
        {
            ListItem<T> foundNode = this.Find(item);
            if (foundNode == null)
            {
                return false;
            }

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Destination array cannot be null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex cannot be less than 0.");
            }

            if (array.Length - arrayIndex < this.count)
            {
                throw new ArgumentException("The number of elements in the source is greater than the available space from arrayIndex to the end of the destination array.");
            }

            ListItem<T> nextNode = this.firstElement;
            int index = arrayIndex;
            do
            {
                array[index] = nextNode.Value;
                index++;
                nextNode = nextNode.NextItem;
            }
            while (nextNode != this.firstElement);
        }

        public bool Remove(T item)
        {
            ListItem<T> currentNode = this.firstElement;
            ListItem<T> previousNode = this.firstElement;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (currentNode != null)
            {
                if (item == null)
                {
                    while (currentNode.Value != null)
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.NextItem;
                        if (currentNode == this.firstElement)
                        {
                            return false;
                        }
                    }

                    this.RemoveItem(currentNode, previousNode);
                    return true;
                }
                else
                {
                    do
                    {
                        if (comparer.Equals(currentNode.Value, item))
                        {
                            this.RemoveItem(currentNode, previousNode);
                            return true;
                        }

                        previousNode = currentNode;
                        currentNode = currentNode.NextItem;
                    }
                    while (currentNode != this.firstElement);
                }
            }

            return false;
        }

        private void RemoveItem(ListItem<T> currentNode, ListItem<T> previousNode)
        {
            if (currentNode == this.firstElement)
            {
                this.firstElement = this.firstElement.NextItem;
            }
            else
            {
                previousNode.NextItem = currentNode.NextItem;
            }

            currentNode.Clear();
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> currentNode = this.firstElement;
            do
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextItem;
            }
            while (currentNode != this.firstElement);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private ListItem<T> Find(T value)
        {
            ListItem<T> currentNode = this.firstElement;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (currentNode != null)
            {
                if (value == null)
                {
                    while (currentNode.Value != null)
                    {
                        currentNode = currentNode.NextItem;
                        if (currentNode == this.firstElement)
                        {
                            return null;
                        }
                    }

                    return currentNode;
                }
                else
                {
                    do
                    {
                        if (comparer.Equals(currentNode.Value, value))
                        {
                            return currentNode;
                        }

                        currentNode = currentNode.NextItem;
                    }
                    while (currentNode != this.firstElement);
                }
            }

            return null;
        }
    }
}