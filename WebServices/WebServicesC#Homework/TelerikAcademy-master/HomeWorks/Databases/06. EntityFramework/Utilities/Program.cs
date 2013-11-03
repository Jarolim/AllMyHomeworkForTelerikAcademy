using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace Utilities
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 2
            Customer newCustmer = new Customer();
            newCustmer.CustomerID = "NEKU";
            newCustmer.CompanyName = "Neulita";
            newCustmer.ContactName = "Neula Kulano";
            newCustmer.ContactTitle = "Owner";
            newCustmer.Address = "Amela str 23";
            newCustmer.City = "Pelon";
            newCustmer.PostalCode = "1231";
            newCustmer.Country = "France";
            newCustmer.Phone = "3443-4323-432";
            newCustmer.Fax = "3245-243";

            Console.WriteLine("Effected rows {0}", DAO.AddCustomer(newCustmer));
            Console.WriteLine("Effected updated rows {0}", DAO.UpdateContactNameTitle(newCustmer, "Milka Mikova", "Saler"));
            Console.WriteLine("Effected rows from delete {0}", DAO.DeleteCustomer("NEKU"));

            //Task 3
            DAO.FindCustomerByCountryOrderYear("Canada", 1997);

            //Task 4
            DAO.FindCustomerByCountryYearSql("Canada", 1997);

            //Task 5
            DAO.FindSaleByDateRegion("Lara", new DateTime(1995, 1, 1), new DateTime(2000, 1, 1));

        }
    }
}