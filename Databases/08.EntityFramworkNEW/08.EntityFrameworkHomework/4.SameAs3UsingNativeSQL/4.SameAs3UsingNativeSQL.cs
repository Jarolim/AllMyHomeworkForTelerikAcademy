using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHomework.Models;

namespace _4.SameAs3UsingNativeSQL
{
    class Program
    {
        public static void CustomersWithOrdersIn1997FromCanada_SQLQuery()
        {
            using (NorthwindEntities northwindDBContext = new NorthwindEntities())
            {

                var customers = northwindDBContext.Database.SqlQuery<string>(@"SELECT c.CompanyName FROM Orders o 
	                                                                         JOIN Customers c ON o.CustomerID = c.CustomerID
                                                                          WHERE YEAR(o.OrderDate) = 1997 AND o.ShipCountry = 'Canada'
                                                                          GROUP BY c.CompanyName");
                northwindDBContext.SaveChanges();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }
        
        static void Main()
        {
            CustomersWithOrdersIn1997FromCanada_SQLQuery();
        }
    }
}
