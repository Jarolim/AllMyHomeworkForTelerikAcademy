using System;

namespace CellularPhone
{
    class Call
    {
        private DateTime timeInstance;
        private string dialedPhoneNumber;
        private uint duration;
        
        public uint Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }
            set
            {
                this.dialedPhoneNumber = value;
            }
        }

        public DateTime TimeInstance
        {
            get
            {
                return this.timeInstance;
            }
            set
            {
                this.timeInstance = value;
            }
        }

        Call(DateTime instant, string number, uint duration)
        {
            this.TimeInstance = instant;
            this.dialedPhoneNumber = number;
            this.Duration = duration;
        }

    }
}
