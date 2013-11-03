using System;

namespace InvalidRangeException.Common
{
    public class InvalidRangeException<T> : ApplicationException
    {
        private T minValue;
        private T maxValue;

        public InvalidRangeException(string msg, T minValue, T maxValue) : base(msg)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public T MaxValue
        {
            get
            {
                return maxValue;
            }
        }

        public T MinValue
        {
            get
            {
                return minValue;
            }
            
        }
    }
}