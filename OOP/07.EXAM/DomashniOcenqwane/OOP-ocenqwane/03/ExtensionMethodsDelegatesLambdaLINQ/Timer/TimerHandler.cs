using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timer
{
    class TimerHandler
    {
        public static void PrintMessage(int ticks)
        {
            Console.WriteLine("Ticking...: {0}", ticks);
        }

        static void Main(string[] args)
        {
            TimerDelegate timerElapsedDelegate = new TimerDelegate(PrintMessage);

            Timer testTimer = new Timer(5, 1, timerElapsedDelegate);

            Thread thread = new Thread(new ThreadStart(testTimer.Start));
            thread.Start();
        }
    }
}
