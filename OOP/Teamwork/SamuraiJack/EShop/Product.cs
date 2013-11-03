using System;

namespace EShop
{
    public class Product : IComment, IPrice
    {
        private string name;
        private decimal price;
        private string comment;
        private int quantity;
        private int productID;

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ProductNotAvailableException("Sorry! Product is not available!", this);
                }
                this.quantity = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input! You should enter positive number for product price.");
                }
                this.price = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter product name.");
                }
                this.name = value;
            }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public int ProductID
        {
            get { return this.productID; }
            set
            {
                if (value <= 0)
                {
                    throw new ProductNotAvailableException(
                        "Invalid input! You should enter positive number for product ID.", this);
                }
                this.productID = value;
            }
        }

        public Product(string name, decimal price, int productID, int quantity = 0, string comment = null)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Comment = comment;
            this.ProductID = productID;
        }

        public static Product CreateProduct()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter product id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter comment:");
            string comment = Console.ReadLine();
            return new Product(name, price, id, quantity, comment);
        }

        public void PrintComment()
        {
            Console.WriteLine("** {0} **", this.Comment);
        }

        public override string ToString()
        {
            return string.Format("Product ID: {0}\r\nType: {1}\r\nName: {2}\r\nPrice: {3}\r\nQuantity: {4}",
                this.ProductID, this.GetType().Name, this.Name, this.Price, this.Quantity);
        }

        public static bool Equals(Product firstProduct, Product secondProduct)
        {
            bool isEqual = (firstProduct.ProductID == secondProduct.ProductID);
            return isEqual;
        }

        public static bool operator ==(Product firstProduct, Product secondProduct)
        {
            return Equals(firstProduct, secondProduct);
        }

        public static bool operator !=(Product firstProduct, Product secondProduct)
        {
            return !Equals(firstProduct, secondProduct);
        }

        public override bool Equals(object obj)
        {
            return Equals(this, obj as Product);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public decimal CalculateTotalProductsPrice()
        {
            decimal totalPrice = this.Price * this.Quantity;
            return totalPrice;
        }
    }
}