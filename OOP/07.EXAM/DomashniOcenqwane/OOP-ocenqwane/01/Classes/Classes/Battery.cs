using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Battery
    {
        public enum BatteryType
        {
            Li_Ion, NiMH, NiCd
        }
        private BatteryType battType;
        public BatteryType Type
        {
            get
            {
                return this.battType;
            }
            set
            {
                this.battType = value;
            }
        }

        private string model;
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

        private uint hoursIdle;
        public uint HoursIdle
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

        private uint hoursTalk;
        public uint HoursTalk
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
        public Battery()
        {
            this.battType = BatteryType.Li_Ion;
            this.model = null;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
        }
        public Battery(BatteryType battType)
        {
            this.battType = battType;
            this.model = null;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
        }
        public Battery(BatteryType battType, string model)
        {
            this.battType = battType;
            this.model = model;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
        }
        public Battery(BatteryType battType, string model, uint hoursIdle, uint hoursTalk)
        {
            this.battType = battType;
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(String.Format("Battery Type: {0}\n", battType));
            info.Append(String.Format("Battery Model: {0}\n", model));
            info.Append(String.Format("Battery hours in idle: {0}\n", hoursIdle));
            info.Append(String.Format("Battery hours talking: {0}\n", hoursTalk));
            return info.ToString();
        }
    }
}
