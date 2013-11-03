using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;

namespace TestShapes
{
    class TestShapes
    {
        static void Main(string[] args)
        {
            List<Shape> figures = new List<Shape>() {
                
                new Retangle(14,16),
                new Triangle(17,18),
                new Circle(5)

            };

            foreach (var item in figures)
            {
                Console.WriteLine(item.CalculateSurface());
            }
        }
    }
}