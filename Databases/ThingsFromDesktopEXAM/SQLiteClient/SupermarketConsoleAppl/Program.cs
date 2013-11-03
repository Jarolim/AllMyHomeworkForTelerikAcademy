using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteClientModel;

namespace SQLiteExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dbFile = @"C:\Users\Deblia\Desktop\TWDatabases\SQLite\Supermarket.db";
            //if (File.Exists(dbFile)) File.Delete(dbFile);

            //var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);

            SQLiteDb context = new SQLiteDb();
            var records = from r in context.Taxes
                          select r;
            foreach (var record in records)
            {
                Console.WriteLine("ID: {0}, Product_name: {1}, Tax: {2}", record.ID, record.Product_Name, record.Tax1);
            }
           
        }

        
    }
}