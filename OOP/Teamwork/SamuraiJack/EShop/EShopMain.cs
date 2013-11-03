using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EShop
{
    public class EShopMain
    {
        public static void Main()
        {
            ShopInformation shopInfo = ShopInformation.Instance;
            Admin.Register("admin", "admin");
            Customer.Register("user", "user");
            Customer.Register("premium", "premium");

            StreamReader reader = new StreamReader("../../Products.txt", Encoding.GetEncoding("UTF-8"));
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    int productID = int.Parse(line);
                    string productName = reader.ReadLine();
                    decimal productPrice = decimal.Parse(reader.ReadLine());
                    int productQuantity = int.Parse(reader.ReadLine());
                    ShopInformation.AvailableProducts.Add(new Product(productName, productPrice, productID, productQuantity));
                    line = reader.ReadLine();
                }
            }

            ShopInformation.Administrators[0].LogIn();
            ShopInformation.Administrators[0].MakePromotion("../../Promotions.txt");
            ShopInformation.Administrators[0].MakePremiumCustomer("premium", "premium");
            //Movie movie = new Movie("a", 10, 10000, 20, "", "bg", 90, (MovieGenre)1);
            //ShopInformation.Administrators[0].AddAvailableProduct(movie);
            ShopInformation.Administrators[0].LogOut();
            while (!Console.KeyAvailable)
            {
                LogInPublisher publisher = new LogInPublisher();
                LogInSubscriber subscriber = new LogInSubscriber("Subscriber", publisher);
                publisher.Execute(3);
            }
            Console.ReadLine();

            ShopUI.LogInMenu();

            Console.WriteLine("Price of all available products in the shop is ${0:F2}\r\n", 
                shopInfo.CalculateTotalProductsPrice());

            Console.WriteLine(ShopInformation.PrintShopCustomers());

            Console.WriteLine(ShopInformation.PrintAvailableProducts());

            Console.WriteLine(ShopInformation.PrintPromotionProducts());

            Console.WriteLine(ShopInformation.PrintSoldProducts());
        }
    }
}