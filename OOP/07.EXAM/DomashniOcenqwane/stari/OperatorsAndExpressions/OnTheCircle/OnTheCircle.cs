using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnTheCircle
{
    class OnTheCircle
    {
        static void Main(string[] args)
        {
            int x;
            int y;
            string unformattedNumber;
            unformattedNumber = Console.ReadLine();
            x = int.Parse(unformattedNumber);
            unformattedNumber = Console.ReadLine();
            y = int.Parse(unformattedNumber);
            Console.WriteLine(25 == (x * x) + (y * y));
        }
    }
}
