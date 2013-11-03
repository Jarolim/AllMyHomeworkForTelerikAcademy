using System;
using System.IO;

namespace EShop
{
    public static class ShopUI
    {
        public static void LogInMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Login as customer.");
                Console.WriteLine("2.Login as admin.");
                Console.WriteLine("3.Exit");
                Console.WriteLine("Make your choice");
                int choice = MakeChoice(1, 3);
                if (choice == 3) return;
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                switch (choice)
                {
                    case 1: // Login as customer
                        {
                            try
                            {
                                Customer customer = new Customer(username, password);
                                customer = (Customer)customer.LogIn();
                                if (customer != null)
                                {
                                    Console.WriteLine("Logged in successful.");
                                    CustomerMenu(customer);
                                }
                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 2: // Login as admin
                        {
                            try
                            {
                                Admin admin = new Admin(username, password);
                                admin = (Admin)admin.LogIn();
                                if (admin != null)
                                {
                                    Console.WriteLine("Logged in successful.");
                                    AdminMenu(admin);
                                }
                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                }
            }
        }

        private static void AddProductMenu(Admin user)
        {
            Console.WriteLine("1.Add new book.");
            Console.WriteLine("2.Add new game.");
            Console.WriteLine("3.Add new movie.");
            Console.WriteLine("4.Add new music.");
            Console.WriteLine("5.Back");
            Console.WriteLine("Make choice.");
            int choice = MakeChoice(1, 5);
            try
            {
                switch (choice)
                {
                    case 1: // Create book
                        {
                            user.AddAvailableProduct(Book.CreateBook());
                            Console.WriteLine("Added successfull.");
                            PressAnyKey();
                            break;
                        }
                    case 2: // Create game
                        {
                            user.AddAvailableProduct(Game.CreateGame());
                            Console.WriteLine("Added successfull.");
                            PressAnyKey();
                            break;
                        }
                    case 3: // Create movie
                        {
                            user.AddAvailableProduct(Movie.CreateMovie());
                            Console.WriteLine("Added successfull.");
                            PressAnyKey();
                            break;
                        }
                    case 4: // Create music
                        {
                            user.AddAvailableProduct(Music.CreateMusic());
                            Console.WriteLine("Added successfull.");
                            PressAnyKey();
                            break;
                        }
                    case 5: PressAnyKey(); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "! Try again.");
            }
        }

        private static void AdminMenu(Admin user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Add product in shop.");
                Console.WriteLine("2.Remove product from shop.");
                Console.WriteLine("3.Change product price.");
                Console.WriteLine("4.Make promotion.");
                Console.WriteLine("5.Make premium customer.");
                Console.WriteLine("6.Change product quantity.");
                Console.WriteLine("7.View all products in shop.");
                Console.WriteLine("8.View all sold products.");
                Console.WriteLine("9.Logout.");
                Console.WriteLine("Make your choice");
                int choice = MakeChoice(1, 9);
                switch (choice)
                {
                    case 1: // add product
                        {
                            AddProductMenu(user);
                            break;
                        }
                    case 2:// remove product
                        {
                            Console.WriteLine("Enter product id:");
                            int id = int.Parse(Console.ReadLine());
                            user.RemoveAvailableProduct(id);
                            PressAnyKey();
                            break;
                        }
                    case 3: // change price
                        {
                            Console.WriteLine("Enter product id:");
                            int productID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new price:");
                            decimal price = decimal.Parse(Console.ReadLine());
                            user.ChangePrice(productID, price);
                            PressAnyKey();
                            break;
                        }
                    case 4: // make promotion
                        {
                            try
                            {
                                Console.WriteLine("Enter file name:");
                                string file = Console.ReadLine();
                                user.MakePromotion(file);
                            }
                            catch (IOException ioe)
                            {
                                Console.WriteLine(ioe.Message);
                            }
                            PressAnyKey();
                            break;
                        }
                    case 5: // make premium customer
                        {
                            Console.WriteLine("Enter customer username:");
                            string customerName = Console.ReadLine();
                            Console.WriteLine("Enter customer password:");
                            string customerPassword = Console.ReadLine();
                            user.MakePremiumCustomer(customerName, customerPassword);
                            PressAnyKey();
                            break;
                        }
                    case 6: // change quantity
                        {
                            ChangeQuantityMenu(user);
                            break;
                        }
                    case 7: // view all products
                        {
                            Console.WriteLine(ShopInformation.AvailableProducts);
                            PressAnyKey();
                            break;
                        }
                    case 8: // view all sold products
                        {
                            Console.WriteLine(ShopInformation.SoldProducts);
                            PressAnyKey();
                            break;
                        }
                    case 9:
                        {
                            user.LogOut();
                            return;
                        }
                }
            }
        }

        private static void ChangeQuantityMenu(Admin user)
        {
            Console.WriteLine("1.Add quantity.");
            Console.WriteLine("2.Remove quantity");
            int choice = MakeChoice(1, 2);
            Console.WriteLine("Enter product ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity to add/remove");
            int quantity = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                user.AddQuantity(id, quantity);
            }
            else if (choice == 2)
            {
                user.RemoveQuantity(id, quantity);
            }
            PressAnyKey();
        }

        private static void CustomerMenu(Customer user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Add product to cart.");
                Console.WriteLine("2.Remove product from cart.");
                Console.WriteLine("3.View products in cart.");
                Console.WriteLine("4.Empty cart.");
                Console.WriteLine("5.Buy products in cart.");
                Console.WriteLine("6.Logout.");
                Console.WriteLine("Make your choice");
                int choice = MakeChoice(1, 6);
                switch (choice)
                {
                    case 1: // add product to cart
                        {
                            Console.WriteLine(ShopInformation.PrintAvailableProducts());
                            try
                            {
                                Console.WriteLine("Choose product ID:");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter quantity:");
                                int quantity = int.Parse(Console.ReadLine());
                                user.AddNewItemToCart(id, quantity);
                            }
                            catch (ProductNotAvailableException pnae)
                            {
                                Console.WriteLine(pnae.Message);
                            }
                            PressAnyKey();
                            break;
                        }
                    case 2://remove product from cart
                        {
                            Console.WriteLine(user.Cart.CartList);
                            Console.WriteLine("Choose product ID:");
                            int id = int.Parse(Console.ReadLine());
                            user.RemoveItemFromCart(id);
                            PressAnyKey();
                            break;
                        }
                    case 3: // view products in cart
                        {
                            Console.WriteLine(user.Cart.CartList);
                            PressAnyKey();
                            break;
                        }
                    case 4: // empty cart
                        {
                            user.EmptyCart();
                            Console.WriteLine("Cart is empty.");
                            PressAnyKey();
                            break;
                        }
                    case 5: // Buy products in cart
                        {
                            user.BuyCart();
                            PressAnyKey();
                            break;
                        }
                    case 6:
                        {
                            user.LogOut();
                            return;
                        }
                }
            }
        }

        private static int MakeChoice(int min, int max)
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) && choice < min && choice > max)
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
            return choice;
        }

        private static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}