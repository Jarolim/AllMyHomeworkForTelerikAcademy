using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEvent
{
    public class Subscriber
    {
        public void Subscribe(Publisher publisher)
        {
            publisher.RaiseCustomEvent += new Publisher.TimerDelegate(Message);
        }

        public void Message(Publisher publisher, EventArgs e)
        {
            Console.WriteLine(publisher.CurrentRepetition);
        }
    }
}
