using System;
using System.Text;
using System.Collections.Generic;

namespace CellularPhone
{
    class GSM
    {
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery gsmBattery;
        private Display gsmDisplay;
        private List<Call> callHistory = new List<Call>();
        private static readonly GSM iPhone4S = new GSM("iPhone 4S", "Apple", 99, "Pencho Slaveikov",
            new Battery("TRES-423", 200, 14, BatteryType.LiIon), new Display(3.5f, 4000000000));

        public GSM(string model, string manufacturer) : this(model, manufacturer, null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal? price) : this(model, manufacturer, price, null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner) : this(model, manufacturer, price, owner, new Battery(), new Display())
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.GsmBattery = battery;
            this.GsmDisplay = display;
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public Display GsmDisplay
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

        public Battery GsmBattery
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

        public decimal? Price
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

        // price per minute in BGN, call length in seconds

        public decimal CalculateBill(decimal pricePerMinute)
        {
            decimal totalCallLengthInMinutes = 0;

            foreach (var call in callHistory)
            {
                totalCallLengthInMinutes += (call.Duration / 60);
            }

            return totalCallLengthInMinutes * pricePerMinute;
        }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            CallHistory = new List<Call>();
        }

        public string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(String.Format("Model:             {0,26}", this.Model));
            info.Append(String.Format("\nManufacturer:      {0,26}", this.Manufacturer));
            info.Append(String.Format("\nPrice:             {0,26}", this.Price));
            info.Append(String.Format("\nOwner:             {0,26}", this.Owner));
            info.Append(String.Format("\nBattery model:     {0,26}", this.gsmBattery.Model));
            info.Append(String.Format("\nBattery hours idle:{0,26}", this.gsmBattery.HoursIdle));
            info.Append(String.Format("\nBattery hours talk:{0,26}", this.gsmBattery.HoursTalk));
            info.Append(String.Format("\nBattery type:      {0,26}", this.gsmBattery.Technology));
            info.Append(String.Format("\nDisplay size:      {0,26}", this.gsmDisplay.Size));
            info.Append(String.Format("\nDisplay colours:   {0,26}", this.gsmDisplay.NumberOfColours));
            return info.ToString();
        }

        static void Main()
        {
        }
    }
}