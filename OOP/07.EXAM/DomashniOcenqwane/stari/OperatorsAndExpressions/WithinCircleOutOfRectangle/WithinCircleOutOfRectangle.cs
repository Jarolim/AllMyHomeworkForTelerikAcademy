using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WithinCircleOutOfRectangle
{
    class WithinCircleOutOfRectangle
    {
        static void Main()
        {
            decimal x = decimal.Parse(Console.ReadLine());
            decimal y = decimal.Parse(Console.ReadLine());
            bool onTheCircle = (x - 1) * (x - 1) + (y - 1) *(y - 1) <= 9; //( X - cx )^2 + ( Y - cy )^2 <= radius^2
            bool outOfRectangle =!(((x >= 1) & (x <= 7)) & ((y >= -3) & (y <= -1)));
            //Console.WriteLine("On the circle: " + onTheCircle);
            //Console.WriteLine("Out of the rectangle: " + outOfRectangle);
            Console.WriteLine(onTheCircle & outOfRectangle);
        }
    }
}
