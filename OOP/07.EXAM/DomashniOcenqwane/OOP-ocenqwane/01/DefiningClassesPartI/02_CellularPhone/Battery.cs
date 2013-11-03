namespace CellularPhone
{
    class Battery
    {
        public string Model;
        public byte? HoursIdle;
        public byte? HoursTalk;

        public Battery() : this(null)
        {
        }

        public Battery(string model) : this(model, null, null)
        {
            this.Model = model;
        }

        public Battery(string model, byte? hoursIdle, byte? hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }
    }
}