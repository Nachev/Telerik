namespace QueueWithList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /*Implement the ADT queue as dynamic linked list. 
    Use generics (LinkedQueue<T>) to allow storing 
    different data types in the queue.*/
    public class LinkedQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private LinkedList<T> container;
        private int size;

        public LinkedQueue()
        {
            this.container = new LinkedList<T>();
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public void Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot enqueue null item.");
            }

            this.container.AddLast(item);
            this.size++;
        }

        public T Dequeue()
        {
            T result = this.container.First.Value;
            this.container.RemoveFirst();
            this.size--;
            return result;
        }

        public T Peek()
        {
            T result = this.container.First.Value;
            return result;
        }

        public void Clear()
        {
            this.container.Clear();
            this.size = 0;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot enqueue null item.");
            }
            return this.container.Contains(item);
        }

        public T[] ToArray()
        {
            T[] result = new T[this.size];
            this.container.CopyTo(result, 0);
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.container.GetEnumerator();
        }
    }
}