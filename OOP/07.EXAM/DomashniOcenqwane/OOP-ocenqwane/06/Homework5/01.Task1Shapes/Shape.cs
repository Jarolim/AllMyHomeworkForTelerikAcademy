using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Task1Shapes
{
    // The abstract class Shape
    public abstract class Shape
    {
        private decimal width;

        public decimal Width
        {
            get { return width; }
            protected set {
                if (value < 0)
                    throw new ArgumentException("Dimensions must always be positive numbers.");
                width = value;
            }
        }

        private decimal height;

        public decimal Height
        {
            get { return height; }
            protected set {
                if (value < 0)
                    throw new ArgumentException("Dimensions must always be positive numbers.");
                height = value;
            }
        }

        // The protected constructor
        protected Shape(decimal width, decimal height)
        {
            this.Height = height;
            this.Width = width;
        }

        public abstract decimal CalculateSurface();

        // Overriding ToString
        public override string ToString()
        {
            StringBuilder result=new StringBuilder(String.Format("{0}", this.GetType().Name));
            result[0] = Char.ToLowerInvariant(result[0]);
            return result.ToString();
        }
    }
}
