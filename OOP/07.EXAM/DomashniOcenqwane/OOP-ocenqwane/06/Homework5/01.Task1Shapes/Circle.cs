using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Task1Shapes
{
    // Class Circle
    class Circle :Shape
    {
        // The constructor ensures that width==height
        public Circle(decimal radius)
            : base(radius, radius)
        {
        }

        public override decimal CalculateSurface()
        {
            return (decimal)Math.PI * this.Width * this.Height;
        }

    }
}
