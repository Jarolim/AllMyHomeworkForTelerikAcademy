using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



namespace GenerateHtml
{
    class Program
    {
        static void Main()
        {

            StringBuilder sb = new StringBuilder();
            //sb.Append("<style>.th {background-color: red;}</style>");
            
            supermarketEntities context = new supermarketEntities();
            var reports = from r in context.SellsReports
                          select r;
            
            PDFTable(sb, reports);

            PDFBuilder.HtmlToPdfBuilder builder = new PDFBuilder.HtmlToPdfBuilder(PageSize.LETTER);
            //builder.ImportStylesheet(AppDomain.CurrentDomain.BaseDirectory + "style.css"); 

            PDFBuilder.HtmlPdfPage page = builder.AddPage();
            page.AppendHtml(sb.ToString());
            byte[] file = builder.RenderPdf();

            string tempFolder = AppDomain.CurrentDomain.BaseDirectory + "PdfResult\\";
            string tempFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-" + Guid.NewGuid() + ".pdf";
            if (Helpers.DirectoryExist(tempFolder))
            {
                if (!File.Exists(tempFolder + tempFileName))
                    File.WriteAllBytes(tempFolder + tempFileName, file);
            }
        }

        private static void PDFTable(StringBuilder sb, IQueryable<SellsReport> reports)
        {
            var date = reports.First().FromDate;
            sb.Append("<table border=\"1\">");
            sb.AppendFormat("<tr bgcolor='#D3D3D3'><td colspan=\"5\">Date: {0}</td></tr>", date.ToString("yyyy-MM-dd"));
            AppendNewTableHeader(sb);
            decimal totalSum = 0;
            decimal grantTotal = 0;
            foreach (var report in reports)
            {

                if (date != report.FromDate)
                {
                    sb.Append("<tr><td colspan=\"4\" align=\"right\">Total sum for " + report.FromDate.ToString("yyyy-MM-dd") + ":</td><td style='font-weight:bold'>" + totalSum + "</td></tr>");
                    //sb.Append("</table>");
                    sb.AppendFormat("<tr bgcolor='#D3D3D3'><td colspan=\"5\">Date: {0}</td></tr>", report.FromDate.ToString("yyyy-MM-dd"));
                    date = report.FromDate;
                    AppendNewTableHeader(sb);
                    grantTotal += totalSum;
                    totalSum = 0;
                }
                decimal sum = report.Quantity * report.UnitPrice;
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", report.Product.Product_Name);
                sb.AppendFormat("<td>{0}</td>", report.Quantity);
                sb.AppendFormat("<td>{0}</td>", report.UnitPrice);
                sb.AppendFormat("<td>{0}</td>", report.Location);
                sb.AppendFormat("<td>{0}</td>", sum);
                totalSum += sum;
                sb.Append("</tr>");
            }
            sb.Append("<tr><td colspan=\"4\" align=\"right\">Total sum for " + date.ToString("yyyy-MM-dd") + ":</td><td style='font-weight:bold'>" + totalSum + "</td></tr>");
            //sb.Append("</table>");
            grantTotal += totalSum;
            sb.Append("<tr><td colspan=\"4\" align=\"right\">Grand Total :</td><td style='font-weight:bold'>" + grantTotal + "</td></tr>");
            sb.Append("</table>");
            
        }

        private static void AppendNewTableHeader(StringBuilder sb)
        {
            //sb.Append("<table border=\"1\">");
            sb.Append("<tr bgcolor='#D3D3D3' style='font-weight:bold'>");
            sb.Append("<td>Product</td>");
            sb.Append("<td>Quantity</td>");
            sb.Append("<td>Unit Price</td>");
            sb.Append("<td>Location</td>");
            sb.Append("<td>Sum</td>");
            sb.Append("</tr>");
        }
    }
}
