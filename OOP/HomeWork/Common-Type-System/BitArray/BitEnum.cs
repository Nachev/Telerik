namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BitEnum : IEnumerator<int>
    {
        private const byte ContainerLength = 64;
        private readonly ulong container;

        /// <summary>
        /// Enumerators are positioned before the first element until the first MoveNext() call. 
        /// </summary>
        private int position = -1;

        public BitEnum(ulong container)
        {
            this.container = container;
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public int Current
        {
            get
            {
                if (this.position < ContainerLength)
                {
                    return (int)((this.container >> this.position) & 1);
                }
                else
                {
                    throw new InvalidOperationException("Index outside the boundaries of the array.");
                }
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.position += 1;
            return this.position < ContainerLength;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}