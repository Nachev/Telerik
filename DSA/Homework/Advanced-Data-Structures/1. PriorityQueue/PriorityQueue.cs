namespace PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 8;
        private int capacity;
        private T[] array;
        private int count;
        private bool priorityMax;

        public PriorityQueue(bool priorityMax = true)
        {
            this.capacity = DefaultCapacity;
            Initialize(priorityMax);
        }

        public PriorityQueue(int initialCapacity, bool priorityMax = true)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentException("Illegal value for initial capacity. Must be non-zero positive value.");
            }

            this.capacity = initialCapacity;
            Initialize(priorityMax);
        }

        public PriorityQueue(ICollection<T> inputArray, bool priorityMax = true)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("Cannot convert null value to priority queue.");
            }

            this.capacity = inputArray.Count;
            Initialize(priorityMax);

            foreach (var item in inputArray)
            {
                this.Enqueue(item);
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Cannot add null value to the queue.");
            }

            if (this.count >= this.capacity)
            {
                this.Resize();
            }

            this.array[this.count] = element;
            if (this.priorityMax)
            {
                this.ShiftMaxUp();
            }
            else
            {
                this.ShiftMinUp();
            }

            this.count++;
        }

        public T Dequeue()
        {
            if (this.count <= 0)
            {
                throw new ApplicationException("Cannot dequeue from empty queue!");
            }

            T headElement = this.array[0];
            this.array[0] = this.array[this.count - 1];
            this.count--;
            if (this.priorityMax)
            {
                this.ShiftMaxDown();
            }
            else
            {
                this.ShiftMinDown();
            }

            return headElement;
        }

        public T Peek()
        {
            if (this.count <= 0)
            {
                throw new ArgumentException("Cannot peek into empty priority queue!");
            }

            return this.array[0];
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", this.array.Take(this.count)));
        }

        private void Initialize(bool priorityMax)
        {
            this.priorityMax = priorityMax;
            this.array = new T[this.capacity];
            this.count = 0;
        }

        private void Resize()
        {
            this.capacity = this.capacity * 2;
            T[] newArray = new T[this.capacity];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void ShiftMinUp()
        {
            this.ShiftUp((x, y) => x.CompareTo(y) < 0);
        }

        private void ShiftMinDown()
        {

            this.ShiftDown(((x, y) => x.CompareTo(y) > 0), ((x, y) => x.CompareTo(y) < 0));
        }

        private void ShiftMaxUp()
        {
            this.ShiftUp((x, y) => x.CompareTo(y) > 0);
        }

        private void ShiftMaxDown()
        {
            this.ShiftDown(((x, y) => x.CompareTo(y) < 0), ((x, y) => x.CompareTo(y) > 0));
        }

        private void ShiftUp(Func<T, T, bool> compare)
        {
            int currentPosition = this.count;
            int parentPosition = (currentPosition - 1) / 2;

            while (currentPosition > 0)
            {
                if (compare(this.array[currentPosition], this.array[parentPosition]))
                {
                    this.Swap(currentPosition, parentPosition);
                }
                else
                {
                    return;
                }

                currentPosition = parentPosition;
                parentPosition = (currentPosition - 1) / 2;
            }
        }

        private void ShiftDown(Func<T, T, bool> compareChildren, Func<T, T, bool> compareToParent)
        {
            int currentPosition = 0;
            int leftChildPosition = (currentPosition * 2) + 1;
            int rightChildPosition = leftChildPosition + 1;

            while (leftChildPosition < this.count)
            {
                int index = leftChildPosition;

                if (rightChildPosition < this.count &&
                    compareChildren(this.array[leftChildPosition], this.array[rightChildPosition]))
                {
                    index = rightChildPosition;
                }

                if (compareToParent(this.array[currentPosition], this.array[index]))
                {
                    return;
                }

                this.Swap(currentPosition, index);

                leftChildPosition = (index * 2) + 1;
                rightChildPosition = leftChildPosition + 1;
                currentPosition = index;
            }
        }

        private void Swap(int first, int second)
        {
            T oldValue = this.array[first];
            this.array[first] = this.array[second];
            this.array[second] = oldValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.array.GetEnumerator();
        }
    }
}
