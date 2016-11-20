using System.Collections.Generic;

namespace LinkedList
{
    public interface ILinkedList<T> : ICollection<T>, IEnumerable<T> 
    {
        void AddAfter(T target, T item);
        void AddBefore(T target, T item);
    }
}