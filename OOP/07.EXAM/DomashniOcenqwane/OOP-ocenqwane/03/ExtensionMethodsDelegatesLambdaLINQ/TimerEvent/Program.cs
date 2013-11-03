using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher(100, 20);
            Subscriber sub = new Subscriber();

            sub.Subscribe(pub);

            Console.WriteLine("This event will repeat 20 times");
            pub.Start();

            pub.Reset();

            Console.WriteLine("This event will repeat 20 times");
            pub.Start();
        }
    }
}
