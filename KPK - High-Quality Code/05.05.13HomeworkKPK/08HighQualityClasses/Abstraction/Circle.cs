using System;

namespace Abstraction
{
    class Circle : Figure
    {
		//Fields:
		private double radius;

		public Circle(double radius)
        {
			if (radius > 0)
			{
				this.Radius = radius;
			}
			else
			{
				throw new ArgumentOutOfRangeException("Radius cannot be a negative number!");
			}
        }

		public double Radius
		{
			get
			{
				return this.radius;
			}

			set
			{
				if (value > 0)
				{
					this.radius = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Radius cannot be a negative number!");
				}
			}
		}

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

		public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
