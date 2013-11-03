using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Problem7
{
	public delegate void TimerDelegate(int ticksCount);
	
	public class Timer
	{
		private int TickCounter { get; set; }
		private int Interval { get; set; }
		private TimerDelegate callback;

		public Timer(int tickCounter, int interval, TimerDelegate callback)
		{
			TickCounter = tickCounter;
			Interval = interval;
			this.callback = callback;
		}

		public void Run()
		{
			int ticks = this.TickCounter;
			while (ticks > 0)
			{
				Thread.Sleep(Interval);
				ticks--;
				this.callback(ticks);
			}
		}
	}
}
