using System;
using System.Text;

namespace CellularPhone
{
    class GSM
    {
        public string Model;
        public string Manufacturer;
        public decimal? Price;
        public string Owner;
        public Battery GSMBattery;
        public Display GSMDisplay;

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
            this.GSMBattery = new Battery();
            this.GSMDisplay = new Display();
        }

        public string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(String.Format("Model:         {0,26}", this.Model));
            info.Append(String.Format("\nManufacturer:  {0,26}", this.Manufacturer));
            info.Append(String.Format("\nPrice:         {0,26}", this.Price));
            info.Append(String.Format("\nOwner:         {0,26}", this.Owner));
            info.Append(String.Format("\nBattery model: {0,26}", this.GSMBattery.Model));
            info.Append(String.Format("\nBattery hours idle: {0,26}", this.GSMBattery.HoursIdle));
            info.Append(String.Format("\nBattery hours talk: {0,26}", this.GSMBattery.HoursTalk));
            info.Append(String.Format("\nBattery type: {0,26}", this.GSMBattery.Technology));
            info.Append(String.Format("\nDisplay size: {0,26}", this.GSMDisplay.Size));
            info.Append(String.Format("\nDisplay colours: {0,26}", this.GSMDisplay.NumberOfColours));
            return info.ToString();
        }

        static void Main()
        {
            GSM mobilePhone = new GSM("6800 Xpress Music", "Nokia");
            Console.WriteLine(mobilePhone.ToString());
        }
    }
}