namespace CellularPhone
{
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd,
        SLA,
        AGM,
        MAh,
        CCA
    }

    class Battery
    {
        public string Model;
        public byte? HoursIdle;
        public byte? HoursTalk;
        public BatteryType Technology;

        public Battery() : this(null)
        {
        }

        public Battery(string model) : this(model, null, null)
        {
            this.Model = model;
        }

        public Battery(string model, byte? hoursIdle, byte? hoursTalk) : this(model, hoursIdle, hoursTalk, BatteryType.LiIon)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public Battery(string model, byte? hoursIdle, byte? hoursTalk, BatteryType technology)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Technology = technology;
        }
    }
}