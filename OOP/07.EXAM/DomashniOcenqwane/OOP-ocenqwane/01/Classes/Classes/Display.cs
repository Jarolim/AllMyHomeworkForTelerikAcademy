using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Display
    {
        private uint width;
        public uint Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        private uint height;
        public uint Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
        private uint colorsCount;
        public uint ColorsCount
        {
            get
            {
                return this.colorsCount;
            }
            set
            {
                this.colorsCount = value;
            }
        }

        public Display()
        {
            this.width = 0;
            this.height = 0;
            this.colorsCount = 0;
        }

        public Display(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            this.colorsCount = 0;
        }

        public Display(uint width, uint height, uint colorsCount)
        {
            this.width = width;
            this.height = height;
            this.colorsCount = colorsCount;
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(String.Format("Dsiplay Width: {0}\n", width));
            info.Append(String.Format("Display Height: {0}\n", height));
            info.Append(String.Format("Display colors count: {0}\n", colorsCount));
            return info.ToString();
        }
    }
}
