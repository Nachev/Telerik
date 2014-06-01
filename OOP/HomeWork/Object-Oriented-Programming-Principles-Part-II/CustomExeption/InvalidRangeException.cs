namespace CustomExeption
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidRangeException<T> : ApplicationException
        where T : struct
    {
        private readonly T minValue;
        private readonly T maxValue;

        public InvalidRangeException() 
        { 
        }

        public InvalidRangeException(T minValue, T maxValue)
            : base(FormatMessage(minValue, maxValue))
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public InvalidRangeException(T minValue, T maxValue, string message)
            : base(FormatMessage(minValue, maxValue, message))
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public InvalidRangeException(string message) : base(message) 
        { 
        }

        public InvalidRangeException(T minValue, T maxValue, Exception inner)
            : base(FormatMessage(minValue, maxValue), inner)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public InvalidRangeException(string message, Exception inner) : base(message, inner) 
        { 
        }

        protected InvalidRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.minValue = info.GetValue<T>("min value");
            this.maxValue = info.GetValue<T>("max value");
        }

        public T MinValue
        {
            get
            {
                return this.minValue;
            }
        }

        public T MaxValue
        {
            get
            {
                return this.maxValue;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("min value", this.minValue);
            info.AddValue("max value", this.maxValue);
            base.GetObjectData(info, context);
        }

        private static string FormatMessage(T minValue, T maxValue, string message = null)
        {
            return string.Format(message + " Invalid value! Range (min: {0} - max: {1}).", minValue, maxValue);
        }
    }
}
