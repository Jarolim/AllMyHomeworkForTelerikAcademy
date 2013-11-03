using System;
using System.Linq;

namespace ClassLibrary
{
    public class Triangle : Shape
    {
        public Triangle(int width, int height) : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }
    }
}