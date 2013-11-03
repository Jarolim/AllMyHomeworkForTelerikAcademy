using System;
using System.Linq;
using Northwind.Model;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Order newOrder = new Order();
            newOrder.CustomerID = "VINET";
            newOrder.EmployeeID = 5;
            newOrder.OrderDate = new DateTime(2012, 3, 31);
            newOrder.RequiredDate = new DateTime(2012, 4, 22);
            newOrder.ShippedDate = new DateTime(2012, 4, 12);
            newOrder.ShipVia = 3;
            newOrder.Freight = 20.05M;
            newOrder.ShipName = "Altaro rego";

            AddOrder(newOrder);

        }

        public static int AddOrder(Order newOrder)
        {
            using (var dataBase = new NorthwindEntities())
            {
                var customer = dataBase.Customers.First(c => c.CustomerID == newOrder.CustomerID);
                if (customer != null)
                {
                    newOrder.ShipAddress = customer.Address;
                    newOrder.ShipCity = customer.City;
                    newOrder.ShipPostalCode = customer.PostalCode;
                    newOrder.ShipCountry = customer.Country;
                }

                dataBase.Orders.Add(newOrder);
                dataBase.Orders.Add(newOrder);
                dataBase.Orders.Add(newOrder);
                return dataBase.SaveChanges();
            }
        }
    }
}
