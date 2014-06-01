namespace Defining_Classes_Part2
{
    using System;

    /*Write a generic class GenericList<T> that keeps a list of elements of some parametric 
     * type T. Keep the elements of the list in an array with fixed capacity which is given 
     * as parameter in the class constructor. Implement methods for adding element, accessing 
     * element by index, removing element by index, inserting element at given position, 
     * clearing the list, finding element by its value and ToString(). Check all input 
     * parameters to avoid accessing elements at invalid positions.*/

    public class GenericList<T>
    {
        private T[] container;
        private bool[] used;

        public GenericList(int size = 20)
        {
            container = new T[size];
            used = new bool[size];
        }

        public T this[int index]
        {
            get
            {
                HandleOutOfRange(index);
                return this.container[index];
            }

            set
            {
                HandleOutOfRange(index);
                this.container[index] = value;
                used[index] = true;
            }
        }

        public void Add(T element)
        {
            for (int index = 0; index < container.Length; index++)
            {
                if (!used[index])
                {
                    this.container[index] = element;
                    used[index] = true;
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            HandleOutOfRange(index);
            if (used[index])
            {
                used[index] = false;
            }
        }

        public void InsertAt(int index, T element)
        {
            HandleOutOfRange(index);
            IsThereSpace(); // TODO
            while (used[index])
            {
                T temp = this.container[index];
                this.container[index] = element;
                element = temp;
                index++;
            }

            this.container[index] = element;
            used[index] = true;
        }

        private void IsThereSpace()
        {
            throw new NotImplementedException();
        }

        private void HandleOutOfRange(int index)
        {
            if (index < 0 || index > this.container.Length)
            {
                throw new IndexOutOfRangeException("Index out of range!");
            }
        }
    }
}
