using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EShop
{
    public class Admin : User
    {
        public Admin(string username, string password, string comment = null)
            : base(username, password, comment)
        {
        }

        public void MakePromotion(string file)
        {
            if (this.IsLogged)
            {
                Promotion promotion = new Promotion();
                StreamReader reader = new StreamReader(file, Encoding.GetEncoding("UTF-8"));
                using (reader)
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        int productID = int.Parse(line);
                        string productName = reader.ReadLine();
                        decimal productPrice = decimal.Parse(reader.ReadLine());
                        promotion.PromotionList.Add(new Product(productName, productPrice, productID));
                        line = reader.ReadLine();
                    }
                }
                ShopInformation.CurrentPromotion.PromotionList.Clear();
                ShopInformation.CurrentPromotion.PromotionList = promotion.PromotionList;
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void MakePremiumCustomer(string username, string password)
        {
            for (int count = 0; count < ShopInformation.Customers.Count; count++)
            {
                if (username.Equals(ShopInformation.Customers[count].Username) &&
                    password.Equals(ShopInformation.Customers[count].Password))
                {
                    PremiumCustomer premium = new PremiumCustomer(ShopInformation.Customers[count].Username,
                        ShopInformation.Customers[count].Password);
                    premium.Information = ShopInformation.Customers[count].Information;
                    ShopInformation.Customers.Add(premium);
                    ShopInformation.Customers.RemoveAt(count);
                    break;
                }
                if (count == ShopInformation.Customers.Count - 1)
                {
                    Console.WriteLine("Invalid input! You entered wrong username or password.");
                }
            }
        }

        public void AddAvailableProduct(Product product)
        {
            if (this.IsLogged)
            {
                for (int count = 0; count < ShopInformation.AvailableProducts.Length; count++)
                {
                    Product currentProduct = ShopInformation.AvailableProducts[count];
                    if (currentProduct.Equals(product))
                    {
                        throw new ArgumentException(
                            "Invalid input! You entered existing product ID. Please choose another one!");
                    }
                }
                ShopInformation.AvailableProducts.Add(product);
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void RemoveAvailableProduct(int id)
        {
            if (this.IsLogged)
            {
                int index = ShopInformation.AvailableProducts.Find(id);
                if (index >= 0)
                {
                    ShopInformation.SoldProducts.Add(ShopInformation.AvailableProducts[index]);
                    ShopInformation.AvailableProducts.RemoveAt(index);
                }
                else
                {
                    throw new ArgumentException(
                        "Invalid input! You entered non-existing product ID. Please choose another one.");
                }
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void ChangePrice(int productID, decimal price)
        {
            if (this.IsLogged)
            {
                int index = ShopInformation.AvailableProducts.Find(productID);
                if (index < 0)
                {
                    Console.WriteLine("Invalid input! You entered non-existing product ID. Please choose another one.");
                    return;
                }
                ShopInformation.AvailableProducts[index].Price = price;
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void AddQuantity(int productID, int quantity)
        {
            if (this.IsLogged)
            {
                int index = ShopInformation.AvailableProducts.Find(productID);
                if (index < 0)
                {
                    Console.WriteLine("Invalid input! You entered non-existing product ID. Please choose another one.");
                    return;
                }
                ShopInformation.AvailableProducts[index].Quantity += quantity;
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public void RemoveQuantity(int productID, int quantity)
        {
            if (this.IsLogged)
            {
                int index = ShopInformation.AvailableProducts.Find(productID);
                if (index < 0)
                {
                    Console.WriteLine("Invalid input! You entered non-existing product ID. Please choose another one.");
                    return;
                }
                ShopInformation.AvailableProducts[index].Quantity -= quantity;
                int indexSold = ShopInformation.SoldProducts.Find(productID);
                ShopInformation.SoldProducts[indexSold].Quantity += quantity;
            }
            else
            {
                Console.WriteLine("This operation is not permitted. You should log on.");
            }
        }

        public override void PrintComment()
        {
            Console.WriteLine("** {0} **", this.Comment);
        }

        public static void Register(string username, string password)
        {
            Admin admin = new Admin(username, password);
            ShopInformation.Administrators.Add(admin);
        }

        public override User LogIn()
        {
            for (int count = 0; count < ShopInformation.Administrators.Count; count++)
            {
                if (this.Username.Equals(ShopInformation.Administrators[count].Username) &&
                    this.Password.Equals(ShopInformation.Administrators[count].Password))
                {
                    ShopInformation.Administrators[count].IsLogged = true;
                    return ShopInformation.Administrators[count];
                }
                if (count == ShopInformation.Administrators.Count - 1)
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
    }
}