using System;

namespace Abstraction
{
    public class Rectangle : Figure
    {
		private double width;
		private double heigth;

		public Rectangle(double width, double height)
		{
			if (width > 0)
			{
				this.Width = width;
			}
			else
			{
				throw new ArgumentOutOfRangeException("Width cannot be a negative number!");
			}

			if (height > 0)
			{
				this.Height = height;
			}
			else
			{
				throw new ArgumentOutOfRangeException("Height cannot be a negative number!");
			}
		}

		public double Width
		{
			get
			{
				return this.width;
			}

			set
			{
				if (value > 0)
				{
					this.width = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Width cannot be a negative number!");
				}
			}
		}

		public double Height
		{
			get
			{
				return this.heigth;
			}

			set
			{
				if (value > 0)
				{
					this.heigth = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Height cannot be a negative number!");
				}
			}
		}

		public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

		public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
