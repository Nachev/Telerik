using System;

namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node<T>
    {
        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public Node(T value) : this()
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public IList<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.Value.GetHashCode();
                result = result * 23 + ((Children != null) ? this.Children.GetHashCode() : 0);
                result = result * 23 + this.HasParent.GetHashCode();
                return result;
            }
        }
    }
}