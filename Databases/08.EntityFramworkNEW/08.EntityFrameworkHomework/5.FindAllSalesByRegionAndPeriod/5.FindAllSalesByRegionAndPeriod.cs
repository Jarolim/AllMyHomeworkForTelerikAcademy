﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHomework.Models;

namespace _5.FindAllSalesByRegionAndPeriod
{
    class Program
    {
        public static void FindSalesBySpecifiedRegionAndPeriod(string region = null, string startDate = null, string endDate = null)
        {
            using (NorthwindEntities northwindDBContext = new NorthwindEntities())
            {
                DateTime startDateParsed = DateTime.Parse(startDate);
                DateTime endDateParsed = DateTime.Parse(endDate);

                var customers = northwindDBContext.Orders
                                                   .Where(o => (o.OrderDate > startDateParsed && o.OrderDate < endDateParsed) || o.ShipCountry == region)
                                                   .GroupBy(o => o.ShipName);
                northwindDBContext.SaveChanges();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Key);
                }
            }
        }

        static void Main()
        {
            FindSalesBySpecifiedRegionAndPeriod(null, "01.05.1995", "01.08.1996");
        }
    }
}
