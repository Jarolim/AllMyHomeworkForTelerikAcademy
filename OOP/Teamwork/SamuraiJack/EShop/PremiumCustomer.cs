using System;
using System.Collections.Generic;

namespace EShop
{
    public class PremiumCustomer : Customer
    {
        public PremiumCustomer(string username, string password, string comment = null)
            : base(username, password, comment)
        {
        }

        public Cart GetPromotion()
        {
            Cart promotionCart = new Cart();
            for (int count = 0; count < this.Cart.CartList.Length; count++)
            {
                Product promotionProduct = this.Cart.CartList[count];
                for (int position = 0; position < ShopInformation.CurrentPromotion.PromotionList.Length; position++)
                {
                    if (promotionProduct == ShopInformation.CurrentPromotion.PromotionList[count])
                    {
                        promotionProduct.Price = ShopInformation.CurrentPromotion.PromotionList[count].Price;
                    }
                }
                promotionCart.AddProduct(promotionProduct);
            }
            return promotionCart;
        }

        public override void BuyCart()
        {
            Cart promotionCart = this.GetPromotion();
            UpdateInfo();
            decimal totalPrice = promotionCart.CalculateTotalProductsPrice();
            this.information.SpendMoney += totalPrice;
            this.information.BoughtItems += promotionCart.CartList.Length;
            foreach (Product item in this.Cart.CartList)
            {
                this.information.BoughtProducts.Add(item);
            }

            this.Cart.EmptyCart();
            BuyPublisher publisher = new BuyPublisher();
            BuySubscriber subscriber = new BuySubscriber("Subscriber", publisher);
            publisher.Execute(totalPrice);
        }
    }
}