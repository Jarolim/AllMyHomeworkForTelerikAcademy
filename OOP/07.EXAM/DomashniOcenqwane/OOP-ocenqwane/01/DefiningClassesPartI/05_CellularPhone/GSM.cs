using System;
using System.Text;

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

        public GSM(string model, string manufacturer, decimal? price, string owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.GsmBattery = new Battery();
            this.GsmDisplay = new Display();
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

        public string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(String.Format("Model:         {0,26}", this.Model));
            info.Append(String.Format("\nManufacturer:  {0,26}", this.Manufacturer));
            info.Append(String.Format("\nPrice:         {0,26}", this.Price));
            info.Append(String.Format("\nOwner:         {0,26}", this.Owner));
            info.Append(String.Format("\nBattery model: {0,26}", this.gsmBattery.Model));
            info.Append(String.Format("\nBattery hours idle: {0,26}", this.gsmBattery.HoursIdle));
            info.Append(String.Format("\nBattery hours talk: {0,26}", this.gsmBattery.HoursTalk));
            info.Append(String.Format("\nBattery type: {0,26}", this.gsmBattery.Technology));
            info.Append(String.Format("\nDisplay size: {0,26}", this.gsmDisplay.Size));
            info.Append(String.Format("\nDisplay colours: {0,26}", this.gsmDisplay.NumberOfColours));
            return info.ToString();
        }

        static void Main()
        {
            GSM mobilePhone = new GSM("6800 Xpress Music", "Nokia");
            Console.WriteLine(mobilePhone.ToString());
        }
    }
}