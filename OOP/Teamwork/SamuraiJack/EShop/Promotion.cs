using System;

namespace EShop
{
    public class Promotion : IComment
    {
        private ProductsList promotionList;
        private string comment;

        public ProductsList PromotionList
        {
            get { return this.promotionList; }
            set
            {
                if (value.Length < 0)
                {
                    throw new ArgumentException("Invalid input! You entered empty promotion list.");
                }
                this.promotionList = value;
            }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public Promotion(string comment = null)
        {
            this.PromotionList = new ProductsList();
        }

        public void PrintComment()
        {
            Console.WriteLine("** {0} **", comment);
        }

        public Cart GetPromotion(Cart currentCart)
        {
            Cart cart = new Cart();
            for (int position = 0; position < currentCart.CartList.Length; position++)
            {
                Product currentProduct = currentCart.CartList[position];
                for (int count = 0; count < promotionList.Length; count++)
                {
                    if (currentProduct == promotionList[count])
                    {
                        currentProduct.Price = promotionList[count].Price;
                    }
                }
                cart.AddProduct(currentProduct);
            }

            return cart;
        }
    }
}