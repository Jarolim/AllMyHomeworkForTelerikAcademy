using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Shape
    {
        private int width;
        private int height;

        public Shape(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
