using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace Utilities
{
    public static class DAO
    {

        public static void FindCustomerByCountryOrderYear(string country, int year)
        {
            using (var dataBase = new NorthwindEntities())
            {
                foreach (var item in dataBase.Orders.Join(dataBase.Customers, (o => o.CustomerID), (c => c.CustomerID), (o, c) =>
                    new { Order = o.OrderDate, Country = o.ShipCountry, Customer = c.CompanyName }).Where(x => x.Country == country && x.Order.Value.Year == year))
                {
                    Console.WriteLine("{0} {1} {2}", item.Customer, item.Order, item.Country);
                }
            }
        }

        public static void FindCustomerByCountryYearSql(string country, int year)
        {
            using (var dataBase = new NorthwindEntities())
            {
                //"SELECT CompanyName +' '+ CONVERT(VARCHAR, OrderDate, 104) +' ' + ShipCity FROM Orders "
                string query = "SELECT CompanyName , OrderDate, ShipCity FROM Orders " +
                                "join Customers " +
                                "on Orders.CustomerID = Customers.CustomerID " +
                                "WHERE year(OrderDate) = {0} and ShipCountry = {1}";
                object[] parameters = { year, country };
                var table = dataBase.Database.SqlQuery<CompanyAndDate>(query, parameters);
                //var table = dataBase.Database.SqlQuery<string>(query, parameters);
                foreach (var info in table)
                {
                    Console.WriteLine("{0,-12} {1, -12} {2}", info.ShipCity, info.OrderDate.ToString("dd/MM/yyyy"), info.CompanyName);
                }
            }
        }

        public static int AddCustomer(Customer newCustomer)
        {
            using (var dataBase = new NorthwindEntities())
            {
                dataBase.Customers.Add(newCustomer);
                return dataBase.SaveChanges();
            }
        }

        public static int UpdateContactNameTitle(Customer customer, string contactName, string contactTitle)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                northwindEntities.Customers.Attach(customer);
                customer.CompanyName = contactName;
                customer.ContactTitle = contactTitle;
                return northwindEntities.SaveChanges();
            }
        }

        public static int DeleteCustomer(string id)
        {
            using (var dataBase = new NorthwindEntities())
            {
                Customer customer = dataBase.Customers.First(x => x.CustomerID == id);
                dataBase.Customers.Remove(customer);
                return dataBase.SaveChanges();
            }

        }

        public static void FindSaleByDateRegion(string region, DateTime start, DateTime end)
        {
            using (var dataBase = new NorthwindEntities())
            {
                foreach (var item in dataBase.Orders.Where(x => x.ShippedDate >= start && x.ShippedDate <= end && x.ShipRegion == region))
               {
                   Console.WriteLine("{0} {1} {2}", item.OrderID, item.ShippedDate.GetValueOrDefault().ToString("dd/MM/yyyy"), item.ShipCity);
                }
            }
        }
    }

    class CompanyAndDate
    {

        public string CompanyName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
