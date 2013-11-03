using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Display
    {
        private int size;
        private int numberOfColors;

        public Display(int size, int numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }

        public Display(int size)
        {
            this.size = size;
        }

        public int Size
        {
            get { return this.size; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Size must be more than 0mm");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value <= 64)
                {
                    throw new ArgumentException("NumberOfColors must be more than 64k");
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }
    }
}