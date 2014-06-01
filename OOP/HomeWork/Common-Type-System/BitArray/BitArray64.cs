namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong container;

        public BitArray64()
        {
            this.container = new ulong();
        }

        public BitArray64(ulong container)
        {
            this.container = container;
        }

        public int this[int index]
        {
            get
            {
                return (int)(this.container >> index) & 1;
            }

            set
            {
                if (value != 0 && value != 1)
                {
                    throw new InvalidOperationException("Bit array can contain only 1 and 0.");
                }

                // Using mask to zero this position
                ulong temp = this.container;
                ulong mask = ~((ulong)1 << index);
                temp &= mask;

                // After required position is zero add the value
                this.container = temp | ((ulong)value << index);
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            BitArray64 temp = obj as BitArray64;
            if (temp == null)
            {
                return false;
            }

            return this.Equals(temp);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new BitEnum(this.container);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool Equals(BitArray64 value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }

            if (ReferenceEquals(this, value))
            {
                return true;
            }

            return this.container == value.container;
        }
    }
}
