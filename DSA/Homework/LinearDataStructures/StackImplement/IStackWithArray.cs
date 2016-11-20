using System;
using System.Collections.Generic;

namespace StackImplement
{
    public interface IStackWithArray<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Clear();
        bool Contains(T item);
        int Count();
        T Peek();
        T Pop();
        void Push(T item);
        T[] ToArray();
        void TrimExcess();
    }
}