using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class XmlController
{

    public static void WriteXmlReport(IEnumerable<XmlReport> reports)
    {

        string fileName = "../../../Sales-by-Vendors-report.xml";
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("sales");

            string vendorName = "";
            bool isFirst = true;
            foreach (var report in reports)
            {
                if (report.VendorName !=vendorName && isFirst == true)
                {
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", report.VendorName);

                    writer.WriteStartElement("summary");
                    writer.WriteAttributeString("date", string.Format("{0:d}", report.FromDate));
                    writer.WriteAttributeString("total-sum", report.Sum.ToString());
                    writer.WriteEndElement();

                    vendorName = report.VendorName;
                    isFirst = false;
                }
                else if (report.VendorName !=vendorName && isFirst == false)
                {
                    writer.WriteEndElement();
                    writer.WriteStartElement("sale");
                    writer.WriteAttributeString("vendor", report.VendorName);

                    writer.WriteStartElement("summary");
                    writer.WriteAttributeString("date", string.Format("{0:d}", report.FromDate));
                    writer.WriteAttributeString("total-sum", report.Sum.ToString());
                    writer.WriteEndElement();

                    vendorName = report.VendorName;
                }
                else
                {
                    writer.WriteStartElement("summary");
                    writer.WriteAttributeString("date", string.Format("{0:d}", report.FromDate));
                    writer.WriteAttributeString("total-sum", report.Sum.ToString());
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();

            writer.WriteEndDocument();
        }
    }
}

