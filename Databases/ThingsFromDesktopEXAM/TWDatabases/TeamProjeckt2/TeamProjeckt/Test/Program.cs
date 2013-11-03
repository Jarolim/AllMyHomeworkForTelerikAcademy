using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSupermarketModel;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (supermarketEntities sqlDb= new supermarketEntities())
            {

            
                string query =
                    "select VendorName, FromDate, SUM(Quantity * UnitPrice) as Sum from SellsReport s " +
                    "inner join Products p on s.ProductID = p.ID " +
                    "inner join Vendors v on p.vendors_ID = v.ID " +
                    "group by VendorName, FromDate " +
                    "order by VendorName";

                var objects = sqlDb.Database.SqlQuery<XmlReport>(query);

                foreach (var item in objects)
                {
                    Console.WriteLine("{0} - {1:d} - {2}", item.VendorName, item.FromDate, item.Sum);
                }

                //var xmlReportsData = sqlDb.SellsReports
                // .Include("Product")
                // .Select(p => new
                // {
                //     VendorName = p.Product.Vendor.VendorName,
                //     FromDate = p.FromDate,
                //     Sum = p.Quantity * p.UnitPrice
                // })
                // .GroupBy(p => new { p.VendorName, p.FromDate });

                //List<object> xmlReportObjects = new List<object>();
                //foreach (var report in xmlReportsData)
                //{
                //    string vName = null;
                //    DateTime? date = null;
                //    decimal sum = 0.0m;
                //    foreach (var atrib in report)
                //    {
                //        vName = atrib.VendorName;
                //        date = atrib.FromDate;
                //        sum += atrib.Sum;
                //    }

                //    xmlReportObjects.Add(new { VendorName = vName,FromDate = date,Sum = sum});
                //}

                //foreach (var item in xmlReportObjects)
                //{
                //    Console.WriteLine(item.ToString());
                //}
            }
        }
    }
}
