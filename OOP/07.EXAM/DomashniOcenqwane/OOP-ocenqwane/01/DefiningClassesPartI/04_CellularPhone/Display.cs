namespace CellularPhone
{
    class Display
    {
        public Display() : this(null)
        {
        }

        public Display(ushort? size) : this(size, null)
        {
            this.Size = size;
        }

        public Display(uint? numberOfColours) : this(null, numberOfColours)
        {
            this.NumberOfColours = numberOfColours;
        }

        public Display(ushort? size, uint? numberOfColours)
        {
            this.Size = size;
            this.NumberOfColours = numberOfColours;
        }

        public ushort? Size;
        public uint? NumberOfColours;
    }
}