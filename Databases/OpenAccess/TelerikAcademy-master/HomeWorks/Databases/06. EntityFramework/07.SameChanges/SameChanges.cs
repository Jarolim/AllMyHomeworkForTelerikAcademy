using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;



    class SameChanges
    {
        static void Main(string[] args)
        {
            Customer newCustmer = new Customer();
            newCustmer.CustomerID = "KULO";
            newCustmer.CompanyName = "Mala";
            newCustmer.ContactName = "Misoto Kulano";
            newCustmer.ContactTitle = "Owner";
            newCustmer.Address = "Amela str 23";
            newCustmer.City = "Pelon";
            newCustmer.PostalCode = "1231";
            newCustmer.Country = "France";
            newCustmer.Phone = "3443-4323-432";
            newCustmer.Fax = "3245-243";

            using (var otherDataBase = new NorthwindEntities())
            {

                using (var dataBase = new NorthwindEntities())
                {
                    otherDataBase.Customers.Add(newCustmer);
                    otherDataBase.SaveChanges();
                    //Customer customer = dataBase.Customers.First(x => x.CustomerID == "KULO");
                    dataBase.Customers.Attach(newCustmer);
                    dataBase.Customers.Remove(newCustmer);
                    dataBase.SaveChanges();
                }
            }
        }
    }