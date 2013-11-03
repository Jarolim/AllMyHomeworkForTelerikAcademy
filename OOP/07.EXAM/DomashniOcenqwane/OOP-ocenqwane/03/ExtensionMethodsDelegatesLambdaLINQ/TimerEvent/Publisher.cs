using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerEvent
{
    public class Publisher
    {
        public delegate void TimerDelegate(Publisher pub, EventArgs e);
        public event TimerDelegate RaiseCustomEvent; 

        private EventArgs e = null;
        public int TimeInterval { get; private set; }
        public int Repetitions { get; private set; }
        public int CurrentRepetition { get; private set; }

        public Publisher(int timeInterval, int repetitions)
        {
            this.TimeInterval = timeInterval;
            this.Repetitions = repetitions;
            this.CurrentRepetition = this.Repetitions;
        }

        public void Start()
        {
            while (this.CurrentRepetition > 0)
            {
                if (RaiseCustomEvent != null)
                {
                    RaiseCustomEvent(this, e);
                }
                Thread.Sleep(TimeInterval);
                this.CurrentRepetition--;
            }
        }

        public void Reset()
        {
            this.CurrentRepetition = this.Repetitions;
        }
    }
}
