namespace DefiningClassesPart2
{
    using System;
    using System.Text;

    /*Write a generic class GenericList<T> that keeps a list of elements of some parametric 
     * type T. Keep the elements of the list in an array with fixed capacity which is given 
     * as parameter in the class constructor. Implement methods for adding element, accessing 
     * element by index, removing element by index, inserting element at given position, 
     * clearing the list, finding element by its value and ToString(). Check all input 
     * parameters to avoid accessing elements at invalid positions.*/

    public class GenericList<T>
        where T : IComparable
    {
        private const int DEFAULT_SIZE = 20;

        private T[] container;
        private int count;

        public GenericList(int size = DEFAULT_SIZE)
        {
            this.container = new T[size];
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
                this.count = value;
            }
        }

        public int Length
        {
            get
            {
                return this.container.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                this.HandleOutOfRange(index);
                return this.container[index];
            }

            set
            {
                this.HandleOutOfRange(index);
                this.container[index] = value;
                this.count++;
            }
        }

        public void Add(T element)
        {
            while (true)
            {
                if (this.count < this.container.Length)
                {
                    this.container[this.count] = element;
                    this.count++;
                    return;
                }

                this.IncreaseSize(this.count);
            }
        }

        public void RemoveAt(int index)
        {
            this.HandleOutOfRange(index);
            while (index < this.count)
            {
                this.container[index] = this.container[index + 1];
                index++;
            }

            this.container[index] = default(T);
            this.count--;
        }

        public void InsertAt(int index, T element)
        {
            this.HandleOutOfRange(index);

            while (index < this.count)
            {
                this.IncreaseSize(index);

                T temp = this.container[index];
                this.container[index] = element;
                element = temp;
                index++;
            }

            this.container[index] = element;
            this.count++;
        }

        public void Clear()
        {
            this.container = new T[DEFAULT_SIZE];
            this.count = 0;
        }

        public int FindByValue(T value)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.container[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        /*Create generic methods Min<T>() and Max<T>() for finding the 
         * minimal and maximal element in the  GenericList<T>.*/

        public T Min()
        {
            var minimal = this.container[0];
            for (int index = 0; index < this.count; index++)
            {
                if (minimal.CompareTo(this.container[index]) < 0)
                {
                    minimal = this.container[index];
                }
            }

            return minimal;
        }

        public T Max()
        {
            var maximal = this.container[0];
            for (int index = 0; index < this.count; index++)
            {
                if (maximal.CompareTo(this.container[index]) > 0)
                {
                    maximal = this.container[index];
                }
            }

            return maximal;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (var index = 0; index < this.count; index++)
            {
                result.Append(this.container[index]).Append(' ');
            }

            result.Length -= 1;
            return result.ToString();
        }

        private void IncreaseSize(int index)
        {
            if (index >= this.container.Length - 1)
            {
                this.container = this.AutoGrow();
            }
        }

        private T[] AutoGrow()
        {
            var bigContainer = new T[this.container.Length * 2];
            for (int i = 0; i < this.container.Length; i++)
            {
                bigContainer[i] = this.container[i];
            }

            return bigContainer;
        }

        private void HandleOutOfRange(int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }
    }
}
