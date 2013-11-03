using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHomework.Models;

namespace _2.ModifyCustomersWithTests
{
    public class DAO
    {
        public static void InsertCustomer(string customerID, string companyName)
        {
            using (NorthwindEntities northwindDBContext = new NorthwindEntities())
            {
                Customer customer = new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                };

                northwindDBContext.Customers.Add(customer);
                northwindDBContext.SaveChanges();

                Console.WriteLine("Customer is inserted");
            }
        }

        public static void UpdateCustomer(string customerID, Customer newCustomer)
        {
            using (NorthwindEntities northwindDBContext = new NorthwindEntities())
            {
                Customer customer = northwindDBContext.Customers.First(x => x.CustomerID == customerID);

                customer.CompanyName = newCustomer.CompanyName;
                customer.ContactName = newCustomer.ContactName;
                customer.ContactTitle = newCustomer.ContactTitle;
                customer.Address = newCustomer.Address;
                customer.City = newCustomer.City;
                customer.Region = newCustomer.Region;
                customer.PostalCode = newCustomer.PostalCode;
                customer.Country = newCustomer.Country;
                customer.Phone = newCustomer.Phone;
                customer.Fax = newCustomer.Fax;

                northwindDBContext.SaveChanges();

                Console.WriteLine("Customer is updated.");
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            using (NorthwindEntities northwindDBContext = new NorthwindEntities())
            {
                Customer customer = northwindDBContext.Customers.First(x => x.CustomerID == customerID);

                northwindDBContext.Customers.Remove(customer);
                northwindDBContext.SaveChanges();

                Console.WriteLine("Customer is deleted.");
            }
        }
    }
}
