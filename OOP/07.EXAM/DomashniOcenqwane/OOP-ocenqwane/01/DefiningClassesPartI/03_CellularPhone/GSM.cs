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

        static void Main()
        {
            System.Console.WriteLine("No functionality implemented");
        }
    }
}