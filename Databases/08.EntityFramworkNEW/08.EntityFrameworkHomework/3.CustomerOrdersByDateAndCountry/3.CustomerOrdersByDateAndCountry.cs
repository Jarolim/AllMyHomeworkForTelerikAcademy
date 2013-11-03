using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHomework.Models;

namespace _3.CustomerOrdersByDateAndCountry
{
    class CustomerOrdersByDateAndCountry
    {
        static void Main(string[] args)
        {
            FindCustomers(new DateTime(1997, 1,1), "Canada");
        }

        static void FindCustomers(DateTime year, string country)
        {
            using (NorthwindEntities northwindDBContext = new NorthwindEntities())
            {

                //var customers = northwindDBContext.Orders
                //                                   .Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")
                //                                   .GroupBy(o => o.Customer.CompanyName)
                //                                   .ToList();
                var customers = 
                    from customer in northwindDBContext.Customers
                    join order in northwindDBContext.Orders
                    on customer.CustomerID equals order.CustomerID
                    where order.ShipCountry == country && order.OrderDate.Value.Year == year.Year

                    select new
                    {
                        CustomerID = customer.CustomerID,
                        OrderDate = order.OrderDate,
                        ShipCountry = order.ShipCountry
                    };

                northwindDBContext.SaveChanges();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} ordered on {1} from {2}", customer.CustomerID, customer.OrderDate, customer.ShipCountry);
                }
            }
        }
    }
}
