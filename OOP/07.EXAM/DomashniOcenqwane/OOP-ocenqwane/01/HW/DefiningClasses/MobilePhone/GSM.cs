using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilePhone
{ 
    public class GSM
    {
        //Fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private List<Call> callHistory;

        private static GSM iPhone4S = new GSM("Iphone4S", "China", "Asparuh", 500);
        //END Fields

        //Constructors
        public GSM()
        {
        }

        public GSM(string model, string manufacturer, string owner, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }

        public GSM(string model, string manufacturer, string owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.owner = owner;
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }
        //END Constructors

        //Properties
        public string Model
        {
            get { return this.model; }
            set
            {
                string pattern = @"[a-zA-Z0-9 -_]{2,50}";
                Match match = Regex.Match(value, pattern);
                if (!match.Success)
                {
                    throw new ArgumentException("The model is not correct. Model must be between 2 and 50 symbols!");
                }
                else if (value.Length == 0)
                {
                    throw new ArgumentException("The model cannot be empty!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                string pattern = @"[A-Z][a-zA-Z0-9-_]{2,50}";
                Match match = Regex.Match(value, pattern);
                if (!match.Success)
                {
                    throw new ArgumentException("The manufacturer is not correct. manufacturer must be between 2 and 50 symbols!");
                }
                else if (value.Length == 0)
                {
                    throw new ArgumentException("The manufacturer cannot be empty!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be more than 0.00");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set
            {
                string pattern = @"[A-Z][a-zA-Z ]{3,50}";
                Match match = Regex.Match(value, pattern);
                if (!match.Success)
                {
                    throw new ArgumentException("The owner is not correct. owner must be between 3 and 50 symbols!");
                }
                else if (value.Length == 0)
                {
                    throw new ArgumentException("The owner cannot be empty!");
                }
                else
                {
                    this.owner = value;
                }
            }
        }

        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }
        //END Properties

        //Methods
        //Override ToString
        public override string ToString()
        {
            return string.Format("Model: {0} \n\rManufacturer: {1} \n\rPrice: {2} \n\rOwner: {3} \n\r", model, manufacturer, price, owner);
        }

        //Add CallHistory
        public void AddCall(Call newCall)
        {
            if (callHistory == null)
            {
                callHistory = new List<Call>();
                callHistory.Add(newCall);
            }
            else
            {
                callHistory.Add(newCall);
            }
        }

        //Delete some Number from CallHistory
        public void RemoveCall(int index)
        {
            int callIndex = index;
            callHistory.RemoveAt(callIndex);
        }

        //Empty CallHistory
        public void EmptyCallHistory()
        {
            callHistory.Clear();
        }

        //Calculate Price
        public decimal CalculatePrice(decimal pricePerMin)
        {
            decimal dureation = 0;
            foreach (var call in this.CallHistory)
            {
                dureation += call.Duration/600m;
            }
            decimal priceForCallHistory = pricePerMin * dureation;
            return priceForCallHistory;
        }
    }
}