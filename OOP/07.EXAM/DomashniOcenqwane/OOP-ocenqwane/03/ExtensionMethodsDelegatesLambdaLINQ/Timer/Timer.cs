using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timer
{
    public delegate void TimerDelegate(int ticksCount);

    public class Timer
    {
        public int TicksCount { get; private set; }
        public int Interval { get; private set; }
        public TimerDelegate Callback { get; set; } 

        public Timer(int tickCounter, int interval, TimerDelegate callback)
        {
            this.TicksCount = tickCounter;
            this.Interval = interval;
            this.Callback = callback;
        }

        public void Start()
        {
            int ticks = this.TicksCount;
            while (ticks > 0)
            {
                Thread.Sleep(Interval * 1000);
                this.Callback(ticks);
                ticks--;
            }
        }
    }
}
