using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSupermarketModel;


public class SQLControler
{
    public static void WriteProducts(ICollection<Product> products)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Products.Select(x => x.ID).ToList();

            foreach (var product in products)
            {
                if (!ids.Contains(product.ID))
                {
                    sqlDB.Products.Add(product);
                }

            }

             sqlDB.SaveChanges();
        }
    }

    public static void WriteMesures(ICollection<Mesure> mesures)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Mesures.Select(x => x.ID).ToList();
            foreach (var mesure in mesures)
            {
                if (!ids.Contains(mesure.ID))
                {

                    sqlDB.Mesures.Add(mesure);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static void WriteVendors(ICollection<Vendor> vendors)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.Vendors.Select(x => x.ID).ToList();

            foreach (var vendor in vendors)
            {
                if (!ids.Contains(vendor.ID))
                {
                    sqlDB.Vendors.Add(vendor);
                }
            }

            sqlDB.SaveChanges();
        }
    }

    public static void WriteSellsReports(ICollection<SellsReport> reports)
    {
        using (supermarketEntities sqlDB = new supermarketEntities())
        {
            List<int> ids = sqlDB.SellsReports.Select(x => x.ID).ToList();

            foreach (var report in reports)
            {
                if (!ids.Contains(report.ID))
                {
                    sqlDB.SellsReports.Add(report);
                }
            }

            sqlDB.SaveChanges();
        }
    }
}

