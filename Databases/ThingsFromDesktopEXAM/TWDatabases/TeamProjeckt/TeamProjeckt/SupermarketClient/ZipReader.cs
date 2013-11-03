using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Data;
using System.Data.OleDb;
using SqlSupermarketModel;


public class ZipReader
{
    public static ICollection<SellsReport> ReadFromRar()
    {

        string zipPath = @"..\..\..\Sample-Sales-Reports.zip";
        string unzipDirectory = @"..\..\..\ExtractedZip";
        UnzipFile(zipPath, unzipDirectory);

        List<SellsReport> reports = new List<SellsReport>();
        FindExcelFiles(unzipDirectory,reports);
        
        Directory.Delete(unzipDirectory, true);

        return reports;
    }

    private static void FindExcelFiles(string directoryPath,List<SellsReport> reports)
    {
        var excelFiles = Directory.EnumerateFiles(directoryPath, "*.xls");
        foreach (var file in excelFiles)
        {
            ReadExcelsFromDirectory(file,reports);
        }

        var directories = Directory.EnumerateDirectories(directoryPath);
        foreach (var directory in directories)
        {
            try
            {
                FindExcelFiles(directory,reports);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }

    private static void ReadExcelsFromDirectory(string filePath, List<SellsReport> reports)
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

       
        for (int i = 2; i < dt.Rows.Count - 2; i++)
        {
            string location = dt.Rows[0][0].ToString();

            SellsReport report = new SellsReport()
            {
                Location = location,
                ProductID = int.Parse(dt.Rows[i][0].ToString()),
                Quantity = int.Parse(dt.Rows[i][1].ToString()),
                UnitPrice = decimal.Parse(dt.Rows[i][2].ToString())
            };

            reports.Add(report);
        }
    }

    private static void UnzipFile(string zipPath, string unzipDirectory)
    {
        ZipFile.ExtractToDirectory(zipPath, unzipDirectory);
    }
}


