using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeUtility
{
    public class Circle:Shape
    {
        public Circle(double width) : base(width, width)
        {
        }

        public override double Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }

        public override double CalculateSurface()
        {
            return Math.PI* Math.Pow(this.Width/2, 2);//http://mathcentral.uregina.ca/QQ/database/QQ.09.06/s/lori1.html
        }
    }
}
