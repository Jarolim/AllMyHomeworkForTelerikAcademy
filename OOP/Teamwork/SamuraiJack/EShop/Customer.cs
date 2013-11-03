using System;
using System.Text;

namespace EShop
{
    public class Customer : User
    {
        private Cart cart;
        protected CustomerInformation information;

        public Cart Cart
        {
            get { return this.cart; }
            private set { this.cart = value; }
        }

        public CustomerInformation Information
        {
            get { return this.information; }
            set { this.information = value; }
        }

        public Customer(string username, string password, string comment = null)
            : base(username, password, comment)
        {
            this.Cart = new Cart();
            this.Information = new CustomerInformation(0);
        }

        public void AddNewItemToCart(int id, int quantity)
        {
            if (this.IsLogged)
            {
                int index = ShopInformation.AvailableProducts.Find(id);
                if (index >= 0)
                {
                    Product productToAadd = ShopInformation.AvailableProducts[index];

                    if (quantity > productToAadd.Quantity)
                    {
                        throw new ProductNotAvailableException("Sorry! There is not enough quantity.", productToAadd);
                    }
                    else
                    {
                        Product product = new Product(
                            productToAadd.Name, productToAadd.Price, productToAadd.ProductID, quantity);
                        this.Cart.AddProduct(product);
                    }
                }
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void RemoveItemFromCart(int id)
        {
            if (this.IsLogged)
            {
                int index = this.Cart.CartList.Find(id);
                if (index >= 0)
                {
                    this.Cart.RemoveProductAt(index);
                }
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void EmptyCart()
        {
            if (this.IsLogged)
            {
                this.Cart.EmptyCart();
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        protected void UpdateInfo()
        {
            for (int count = 0; count < this.Cart.CartList.Length; count++)
            {
                Product currentProduct = this.Cart.CartList[count];
                for (int position = 0; position < this.information.BoughtProducts.Length; position++)
                {
                    Product boughtProduct = this.information.BoughtProducts[position];
                    if (currentProduct.Equals(boughtProduct))
                    {
                        this.information.BoughtProducts[position].Quantity += currentProduct.Quantity;
                        break;
                    }
                    if (position == this.information.BoughtProducts.Length - 1)
                    {
                        this.information.BoughtProducts.Add(currentProduct);
                    }
                }

                for (int position = 0; position < ShopInformation.AvailableProducts.Length; position++)
                {
                    Product boughtProduct = ShopInformation.AvailableProducts[position];
                    if (currentProduct.Equals(boughtProduct))
                    {
                        ShopInformation.AvailableProducts[position].Quantity -= currentProduct.Quantity;
                        break;
                    }
                }

                for (int position = 0; position <= ShopInformation.SoldProducts.Length; position++)
                {
                    if (position == ShopInformation.SoldProducts.Length)
                    {
                        ShopInformation.SoldProducts.Add(currentProduct);
                        break;
                    }
                    Product boughtProduct = ShopInformation.SoldProducts[position];
                    if (currentProduct.Equals(boughtProduct))
                    {
                        ShopInformation.SoldProducts[position].Quantity += currentProduct.Quantity;
                        break;
                    }
                }
            }
        }

        public virtual void BuyCart()
        {
            UpdateInfo();
            decimal totalPrice = this.Cart.CalculateTotalProductsPrice();
            this.information.SpendMoney += totalPrice;
            this.information.BoughtItems += this.Cart.CartList.Length;
            foreach (Product item in this.Cart.CartList)
            {
                this.information.BoughtProducts.Add(item);
            }
            this.Cart.EmptyCart();
            BuyPublisher publisher = new BuyPublisher();
            BuySubscriber subscriber = new BuySubscriber("Subscriber", publisher);
            publisher.Execute(totalPrice);
        }

        public override void PrintComment()
        {
            Console.WriteLine("** {0} **", this.Comment);
        }

        public static void Register(string username, string password)
        {
            Customer customer = new Customer(username, password);
            ShopInformation.Customers.Add(customer);
        }

        public override User LogIn()
        {
            for (int count = 0; count < ShopInformation.Customers.Count; count++)
            {
                if (this.Username.Equals(ShopInformation.Customers[count].Username) &&
                    this.Password.Equals(ShopInformation.Customers[count].Password))
                {
                    ShopInformation.Customers[count].IsLogged = true;
                    return ShopInformation.Customers[count];
                }
                if (count == ShopInformation.Customers.Count - 1)
                {
                    Console.WriteLine("Invalid input! You entered wrong username or password.");
                }
            }
            return null;
        }

        public override void LogOut()
        {
            this.IsLogged = false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Username:" + base.Username);
            result.AppendLine("Spend money:" + this.Information.SpendMoney);
            result.AppendLine("Bought items:" + this.Information.BoughtItems);
            result.Append("Bought products: ");
            foreach (Product product in this.Information.BoughtProducts)
            {
                result.AppendLine(product.ToString());
            }

            result.AppendLine("Comment:" + base.Comment);
            return result.ToString();
        }
    }
}