using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHomework.Models;

namespace _2.ModifyCustomersWithTests
{
    class TestInsertUpdateDelete
    {
        static void Main()
        {
            DAO.InsertCustomer("BUBLA", "SamsaraBeach");
            Customer customer = new Customer
            {
                CustomerID = "BUBLA",
                CompanyName = "SamsaraBeach",
                ContactName = "Samuel",
                ContactTitle = "God",
                Address = "Everywhere",
                City = "CityOfGod",
                Region = "Earth",
                PostalCode = "123",
                Country = "Atlantice",
                Phone = "555 Banana Drive",
                Fax = "nah"
            };

            DAO.UpdateCustomer("BUBLA", customer);
            DAO.DeleteCustomer("BUBLA");
        }
    }
}
