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
        private string model;
        private byte? hoursIdle;
        private byte? hoursTalk;
        private BatteryType technology;

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
        public BatteryType Technology
        {
            get
            {
                return this.technology;
            }
            set
            {
                this.technology = value;
            }
        }

        public byte? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }

        public byte? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
    }
}