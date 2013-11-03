using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{

    static void TransferProducts()
    {
        SQLControler.WriteProducts(MySqlController.GetProducts());
    }

    static void TransferMesures()
    {
        SQLControler.WriteMesures(MySqlController.GetMesures());
    }

    static void TransferVendors()
    {
        SQLControler.WriteVendors(MySqlController.GetVendors());
    }

    static void TransferReports()
    {
        SQLControler.WriteSellsReports(ZipReader.ReadFromRar());
    }

    static void TransferDataFromMySqlToSql()
    {
        TransferMesures();
        TransferVendors();
        TransferProducts();
        TransferReports();
    }

    static void WriteReportFromSqlToXmlFile()
    {
        XmlController.WriteXmlReport(SQLControler.GetDataForXmlReport());
    }

    static void Main()
    {
        TransferDataFromMySqlToSql();
        WriteReportFromSqlToXmlFile();
    }
}

