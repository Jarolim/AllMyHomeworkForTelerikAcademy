using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InvalidRangeException
{
    public class InvalidRangeException<T>:ApplicationException
    {
        private T startRange;
        private T endRange;
        private object input;

        public InvalidRangeException(string msg,string input, T start, T end, Exception causeException=null)
            : base(msg,causeException)
        {
            this.startRange = start;
            this.endRange = end;
            this.input = input;
        }

        public object Input
        {
            get
            {
                return this.input;
            }
        }

        public T StartRange
        {
            get
            {
                return this.startRange;
            }
        }

        public T EndRange
        {
            get
            {
                return this.endRange;
            }
        }

        public override string Message
        {
            get
            {
                string message = string.Format("{2} Value {3} is out of the range [{0},{1}]",this.startRange,this.endRange, base.Message,this.input);
                return message;
            }
        }
        
    }
}
