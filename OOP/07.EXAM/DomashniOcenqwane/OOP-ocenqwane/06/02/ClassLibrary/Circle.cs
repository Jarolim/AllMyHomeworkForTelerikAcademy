using System;
using System.Linq;

namespace ClassLibrary
{
    public class Circle : Shape
    {
        public Circle(int R) : base(R, R)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Width * this.Width;
        }
    }
}