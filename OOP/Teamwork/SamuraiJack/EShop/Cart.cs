using System;

namespace EShop
{
    public class Cart : IComment, IPrice
    {
        private ProductsList cartList;
        private string comment;

        public ProductsList CartList
        {
            get { return this.cartList; }
            set
            {
                if (value.Length < 0)
                {
                    throw new ArgumentException("Invalid input! You entered empty promotion list.");
                }
                this.cartList = value;
            }
        }

        public Cart(string comment = null)
        {
            this.CartList = new ProductsList();
            this.Comment = comment;
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public void RemoveProduct(Product product)
        {
            this.CartList.Remove(product);
        }

        public void RemoveProductAt(int index)
        {
            this.CartList.RemoveAt(index);
        }

        public void AddProduct(Product newProduct)
        {
            this.CartList.Add(newProduct);
        }

        public void EmptyCart()
        {
            this.CartList.Clear();
        }

        public void PrintComment()
        {
            Console.WriteLine("** {0} **", this.Comment);
        }

        public decimal CalculateTotalProductsPrice()
        {
            decimal totalPrice = 0.0m;
            foreach (Product product in this.cartList)
            {
                totalPrice += product.Price * product.Quantity;
            }

            return totalPrice;
        }
    }
}