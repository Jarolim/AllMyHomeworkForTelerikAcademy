using System;
using System.Linq;

namespace ClassLibrary
{
    public class Retangle : Shape
    {
        public Retangle(int width, int height) : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}