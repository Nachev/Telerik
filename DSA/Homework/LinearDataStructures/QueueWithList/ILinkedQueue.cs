using System;
using System.Collections.Generic;

namespace QueueWithList
{
    public interface ILinkedQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Count { get; }

        void Clear();
        bool Contains(T item);
        T Dequeue();
        void Enqueue(T item);
        T Peek();
        T[] ToArray();
    }
}