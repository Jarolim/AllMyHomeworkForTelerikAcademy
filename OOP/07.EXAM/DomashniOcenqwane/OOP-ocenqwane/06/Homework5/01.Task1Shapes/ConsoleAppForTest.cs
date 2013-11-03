using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Task1Shapes
{
    class ConsoleAppForTest
    {
        static void Main()
        {
            // Testing the task with different shapes
            Shape[] arr = new Shape[5]{new Rectangle(5,11), new Triangle(4,11.2334m), new Circle(5.67m), 
                new Rectangle(4.1m, 3), new Circle(10)};
            foreach (Shape c in arr)
            {
                Console.WriteLine("The surface of the {0} is {1}", c, c.CalculateSurface());
            }
        }
    }
}
