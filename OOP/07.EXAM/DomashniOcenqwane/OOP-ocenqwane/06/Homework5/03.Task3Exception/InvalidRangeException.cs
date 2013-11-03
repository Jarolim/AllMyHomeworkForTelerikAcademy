using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Task3Exception
{
    // The exception class
    class InvalidRangeException<T> :Exception
    {
        // Fields and properties
        private T start;

        public T Start
        {
            get { return start; }
            private set { start = value; }
        }

        private T end;

        public T End
        {
            get { return end; }
            private set { end = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        // Constructor
        public InvalidRangeException(T start, T end, string message)
        {
            this.Start = start;
            this.End = end;
            this.ErrorMessage = message;
        }
    }
}
