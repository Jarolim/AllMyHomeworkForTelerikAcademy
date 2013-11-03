using System;
using System.Collections.Generic;
using System.Text;

namespace EShop
{
    public class ShopInformation : IPrice
    {
        private static ShopInformation instance;
        private static List<Customer> customers;
        private static List<Admin> administrators;
        private static ProductsList availableProducts;
        private static ProductsList soldProducts;
        private static Promotion currentPromotion;

        public static List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

        public static List<Admin> Administrators
        {
            get { return administrators; }
            set { administrators = value; }
        }

        public static ProductsList AvailableProducts
        {
            get { return availableProducts; }
            set { availableProducts = value; }
        }

        public static ProductsList SoldProducts
        {
            get { return soldProducts; }
            set { soldProducts = value; }
        }

        public static Promotion CurrentPromotion
        {
            get { return currentPromotion; }
            set { currentPromotion = value; }
        }

        public static ShopInformation Instance
        {
            get { return instance; }
        }

        static ShopInformation()
        {
            instance = new ShopInformation();
        }

        private ShopInformation()
        {
            Customers = new List<Customer>();
            Customers.Add(new Customer("test", "test"));
            Administrators = new List<Admin>();
            Administrators.Add(new Admin("Root", "qwerty"));
            AvailableProducts = new ProductsList();
            SoldProducts = new ProductsList();
            CurrentPromotion = new Promotion();
        }

        public decimal CalculateTotalProductsPrice()
        {
            decimal totalPrice = 0.0m;
            foreach (Product item in availableProducts)
            {
                totalPrice += item.Price * item.Quantity;
            }
            return totalPrice;
        }

        public static string PrintAvailableProducts()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Available products: ");
            result.Append(AvailableProducts.ToString());
            return result.ToString();
        }

        public static string PrintSoldProducts()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Sold products: ");
            result.Append(soldProducts.ToString());
            return result.ToString();
        }

        public static string PrintPromotionProducts()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Promotion products: ");
            result.Append(CurrentPromotion.PromotionList.ToString());
            return result.ToString();
        }

        public static string PrintShopCustomers()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Customers: ");
            foreach (Customer customer in customers)
            {
                result.AppendLine(customer.ToString());
            }

            return result.ToString();
        }

        public static string PrintShopAdministrators()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Administrators: ");
            foreach (Admin administrator in administrators)
            {
                result.AppendLine(administrator.Username + administrator.IsLogged + administrator.Comment);
            }

            return result.ToString();
        }
    }
}