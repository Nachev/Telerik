namespace StackImplement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /*Implement the ADT stack as auto-resizable array . 
    Resize the capacity on demand (when no space is 
    available to add / insert a new element).*/
    public class StackWithArray<T> : IStackWithArray<T> where T: IComparable<T>
    {
        private const int DefaultCapacity = 10;

        private T[] container;
        private int pointer;

        public StackWithArray(int initialCapacity = DefaultCapacity)
        {
            this.pointer = 0;
            this.container = new T[initialCapacity];
        }

        public void Push(T item)
        {
            CheckForNullItem("push", item);
            if (this.pointer == this.container.Length)
            {
                T[] grownArray = new T[this.container.Length * 2];
                Array.Copy(this.container, grownArray, this.pointer);
                this.container = grownArray;
            }

            this.container[pointer] = item;
            pointer++;
        }

        public T Peek()
        {
            T result = this.container[this.pointer - 1];
            return result;
        }

        public T Pop()
        {
            T result = this.container[this.pointer - 1];
            this.pointer--;
            return result;
        }

        public void Clear()
        {
            this.pointer = 0;
            this.container = new T[this.container.Length];
        }

        public bool Contains(T item)
        {
            CheckForNullItem("search", item);
            for (int index = 0; index < this.pointer; index++)
            {
                if (this.container[index].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] resultArray = new T[this.pointer];
            for (int index = this.pointer - 1; index >= 0; index--)
			{
                resultArray[index] = this.container[this.pointer - 1 - index];
			}

            return resultArray;
        }      
  
        public int Count()
        {
            return this.pointer;
        }

        public void TrimExcess()
        {
            int length = (int)((this.container.Length) * 0.9);
            if (this.pointer < length)
            {
                T[] trimArray = new T[this.pointer];
                Array.Copy(this.container, 0, trimArray, 0, this.pointer);
                this.container = trimArray;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            T currentItem = this.container[index];
            do
            {
                yield return currentItem;
                index++;
                currentItem = this.container[index];
            }
            while (index < this.pointer);
        }

        private void CheckForNullItem(string method, T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot {0} null item to StackWithArray.", method);
            }
        }
    }
}