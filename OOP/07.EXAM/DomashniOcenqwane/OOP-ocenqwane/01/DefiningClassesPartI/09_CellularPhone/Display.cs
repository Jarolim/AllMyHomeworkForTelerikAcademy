namespace CellularPhone
{
    class Display
    {
        public Display() : this(null)
        {
        }

        public Display(float? size) : this(size, null)
        {
            this.Size = size;
        }

        public Display(uint? numberOfColours) : this(null, numberOfColours)
        {
            this.NumberOfColours = numberOfColours;
        }

        public Display(float? size, uint? numberOfColours)
        {
            this.Size = size;
            this.NumberOfColours = numberOfColours;
        }

        private float? size;
        private uint? numberOfColours;

        public uint? NumberOfColours
        {
            get
            {
                return this.numberOfColours;
            }
            set
            {
                this.numberOfColours = value;
            }
        }

        public float? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}