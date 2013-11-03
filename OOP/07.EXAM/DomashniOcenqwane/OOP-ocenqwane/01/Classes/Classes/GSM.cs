using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class GSM
    {
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

        private string manufacturer;
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }

        private uint price;
        public uint Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        private string owner;
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        private Battery gsmBattery;
        public Battery GSMBattery
        {
            get
            {
                return this.gsmBattery;
            }
            set
            {
                this.gsmBattery = value;
            }
        }
        private Display gsmDisplay;
        public Display GSMDisplay
        {
            get
            {
                return this.gsmDisplay;
            }
            set
            {
                this.gsmDisplay = value;
            }
        }
        public GSM()
        {
            this.model = null;
            this.manufacturer = null;
            this.price = 0;
            this.owner = null;
            this.gsmBattery = null;
            this.gsmDisplay = null;
            this.callHistory = new List<Call>();
        }
        public GSM(string model, string manufactcurer)
        {
            this.model = model;
            this.manufacturer = manufactcurer;
            this.price = 0;
            this.owner = null;
            this.gsmBattery = null;
            this.gsmDisplay = null;
            this.callHistory = new List<Call>();
        }
        public GSM(string model, string manufactcurer, uint price)
        {
            this.model = model;
            this.manufacturer = manufactcurer;
            this.price = price;
            this.owner = null;
            this.gsmBattery = null;
            this.gsmDisplay = null;
            this.callHistory = new List<Call>();
        }
        public GSM(string model, string manufactcurer, uint price, string owner)
        {
            this.model = model;
            this.manufacturer = manufactcurer;
            this.price = price;
            this.owner = owner;
            this.gsmBattery = null;
            this.gsmDisplay = null;
            this.callHistory = new List<Call>();
        }
        public GSM(string model, string manufactcurer, uint price, string owner, Battery battery)
        {
            this.model = model;
            this.manufacturer = manufactcurer;
            this.price = price;
            this.owner = owner;
            this.gsmBattery = battery;
            this.gsmDisplay = null;
            this.callHistory = new List<Call>();
        }
        public GSM(string model, string manufactcurer, uint price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufactcurer;
            this.price = price;
            this.owner = owner;
            this.gsmBattery = battery;
            this.gsmDisplay = display;
            this.callHistory = new List<Call>();
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(String.Format ("Model: {0}\n", this.model));
            info.Append(String.Format ("Manufacturer: {0}\n", this.manufacturer));
            info.Append(String.Format ("Price: ${0}\n", this.price));
            info.Append(String.Format("Owner: {0}\n", this.owner));
            info.Append(gsmBattery.ToString());
            info.Append(gsmDisplay.ToString());
            info.Append("Call history:\n");
            foreach (var call in this.callHistory)
            {
                info.Append(call.ToString());
            }
            return info.ToString();
        }

        static private GSM iPhone4s = new GSM("iPhone 4S", "Apple", 500, "nobody in their right mind", new Battery(Battery.BatteryType.Li_Ion, "some model", 100, 12), new Display(680, 480, 256));
        public static GSM IPhone4S
        {
            get
            {
                return GSM.iPhone4s;
            }
            set
            {
                GSM.iPhone4s = value;
            }
        }
        private List<Call> callHistory;
        public List<Call> CallHistory // automatic property
        {
            get
            {
                return this.callHistory;
            }
            // no setter
        }
        public void ClearCallHistory()
        {
            this.callHistory = new List<Call>();
        }
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }
        public void RemoveCall(int index)
        {
            this.callHistory.RemoveAt(index);
        }
        public decimal CalculateBill(decimal pricePerMinute)
        {
            decimal totatlDuarationInSeconds = 0;
            foreach (var call in this.callHistory)
            {
                totatlDuarationInSeconds += call.CallDuarationInSeconds;
            }
            decimal totatlDuarationInMinutes = Math.Ceiling(totatlDuarationInSeconds / 60);
            return totatlDuarationInMinutes * pricePerMinute;
        }
    }
}
