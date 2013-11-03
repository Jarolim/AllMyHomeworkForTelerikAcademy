using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Call
    {
        public DateTime Date //automatic property
        {
            get;
            set;
        }
        public uint CallDuarationInSeconds
        {
            get;
            set;
        }
        public string DialedNumber
        {
            get;
            set;
        }
        public Call()
        {
            this.Date = new DateTime();
            this.CallDuarationInSeconds = 0;
            this.DialedNumber = null;
        }
        public Call(DateTime date, uint callDuarationInSeconds, string dialedNumber)
        {
            this.Date = date;
            this.CallDuarationInSeconds = callDuarationInSeconds;
            this.DialedNumber = dialedNumber;
        }
        public override string ToString()
        {
            return String.Format("Call to: {0}  on {1} duaration: {2}s\n", this.DialedNumber, this.Date, this.CallDuarationInSeconds);
        }
    }
}
