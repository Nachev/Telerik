namespace CustomExeption
{
    using System;

    public class InvalidRangeException1<T> : ApplicationException
        where T : struct, IComparable
    {
        public InvalidRangeException1(T minValue = default(T), T maxValue = default(T))
        {
            this.HandleMinValueDefault(minValue);
            this.HandelMaxValueDefault(maxValue);
        }

        public InvalidRangeException1(string message, T minValue = default(T), T maxValue = default(T))
            : base(message)
        {
            this.HandleMinValueDefault(minValue);
            this.HandelMaxValueDefault(maxValue);
        }

        public InvalidRangeException1(string message, Exception inner, T minValue = default(T), T maxValue = default(T))
            : base(message, inner)
        {
            this.HandleMinValueDefault(minValue);
            this.HandelMaxValueDefault(maxValue);
        }

        public T MinValue { get; private set; }

        public T MaxValue { get; private set; }

        private void HandelMaxValueDefault(T maxValue)
        {
            if (maxValue.CompareTo(default(T)) != 0)
            {
                this.MaxValue = maxValue;
            }
        }

        private void HandleMinValueDefault(T minValue)
        {
            if (minValue.CompareTo(default(T)) != 0)
            {
                this.MinValue = minValue;
            }
        }
    }
}
