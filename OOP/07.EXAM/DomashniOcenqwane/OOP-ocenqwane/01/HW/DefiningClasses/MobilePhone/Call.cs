using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Call
    {
        //Fields
        public string Date { get; set; }
        public string Time { get; set; }
        public string DialedPnoneNumber { get; set; }
        public decimal Duration { get; set; }
        //END Fields

        //Constructor
        public Call(string date, string time, string dialedPnoneNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialedPnoneNumber = dialedPnoneNumber;
            this.Duration = duration;
        }
        //END Constructor

        //Methods
        //Override ToString
        public override string ToString()
        {
            return string.Format("Date: {0} \n\rTime: {1} \n\rDialedPnoneNumber: {2} \n\rDuration: {3} \n\r", Date, Time, DialedPnoneNumber, Duration);
        }
    }
}
