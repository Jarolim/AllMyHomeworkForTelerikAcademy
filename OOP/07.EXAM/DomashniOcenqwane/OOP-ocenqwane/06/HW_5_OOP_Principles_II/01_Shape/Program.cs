using ShapeUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle myTriangle = new Triangle(3, 4);
            Triangle newTriangle = new Triangle(3.5, 4.5);
            Rectangle myRectangle = new Rectangle(4, 5);
            Rectangle newRectangle = new Rectangle(4.5, 5.5);
            Circle myCircle = new Circle(6);
            Circle newCircle = new Circle(4.5);
            Shape[] shapes = new Shape[] { myTriangle, newTriangle, myRectangle, newRectangle, myCircle, newCircle };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
