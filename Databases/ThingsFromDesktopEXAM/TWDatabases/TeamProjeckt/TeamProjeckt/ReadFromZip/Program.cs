using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Data.OleDb;
using System.Data;
using SqlSupermarketModel;

namespace ReadFromZip
{
    class Program
    {
        static void Main()
        {

            string zipPath = @"..\..\..\Sample-Sales-Reports.zip";
            string unzipDirectory = @"..\..\..\ExtractedZip";
            UnzipFile(zipPath, unzipDirectory);
            FindExcelFiles(unzipDirectory);
            Directory.Delete(unzipDirectory,true);

            
        }

        private static void FindExcelFiles(string directoryPath)
        {
            var excelFiles = Directory.EnumerateFiles(directoryPath, "*.xls");
            foreach (var file in excelFiles)
            {
                ReadExcelsFromDirectory(file);
            }

            var directories = Directory.EnumerateDirectories(directoryPath);
            foreach (var directory in directories)
            {
                try
                {
                    FindExcelFiles(directory);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ReadExcelsFromDirectory(string filePath)
        {
            DataTable dt = new DataTable("newtable");

            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;"))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sales$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }
                connection.Close();
            }

            List<SellsReport> repotst = new List<SellsReport>();
            for (int i = 2; i < dt.Rows.Count-2; i++)
            {
                string location = dt.Rows[0][0].ToString();

                SellsReport report = new SellsReport()
                {
                    Location = location,
                    ProductID = int.Parse(dt.Rows[i][0].ToString()),
                    Quantity = int.Parse(dt.Rows[i][1].ToString()),
                    UnitPrice = decimal.Parse(dt.Rows[i][2].ToString())
                };

                repotst.Add(report);
            }

            foreach (var item in repotst)
            {
                Console.WriteLine(item.UnitPrice);
            }

            //foreach (DataRow row in dt.Rows)
            //{
            //    for (int i = 0; i < row.ItemArray.Length; i++)
            //    {
            //        Console.Write(row.ItemArray[i].ToString()+"  ");
            //    }
            //    Console.WriteLine();
            //}
        }

        private static void UnzipFile(string zipPath, string unzipDirectory)
        {
            ZipFile.ExtractToDirectory(zipPath, unzipDirectory);
        }
    }
}
