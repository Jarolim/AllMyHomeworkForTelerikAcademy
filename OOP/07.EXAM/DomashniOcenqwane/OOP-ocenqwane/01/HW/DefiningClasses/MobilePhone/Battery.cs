using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Battery
    {
        private BatteryType model;
        private int hourIdle;
        private int hourTalk;

        public enum BatteryType
        {
            Lilon, NiMH, NiCd
        }

        public Battery(BatteryType model, int hourIdle, int hourTalk)
        {
            this.model = model;
            this.hourIdle = hourIdle;
            this.HourTalk = hourTalk;
        }

        public Battery(int hourIdle, int hourTalk)
        {
            this.hourIdle = hourIdle;
            this.HourTalk = hourTalk;
        }

        public BatteryType Model
        {
            get { return this.model; }
            set
            {
                if (value != BatteryType.Lilon && value != BatteryType.NiCd && value != BatteryType.NiMH)
                {
                    throw new ArgumentException("Invalid BatteryType!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public int HourIdle
        {
            get { return this.hourIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HourIdle cannot be negative!");
                }
                else
                {
                    this.hourIdle = value;
                }
            }
        }

        public int HourTalk
        {
            get { return this.hourTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HourTalk cannot be negative!");
                }
                else
                {
                    this.hourTalk = value;
                }
            }
        }
    }
}