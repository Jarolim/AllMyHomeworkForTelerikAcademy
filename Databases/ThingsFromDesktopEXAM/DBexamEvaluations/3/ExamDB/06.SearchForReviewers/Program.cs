using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookstoreDB.Data;

namespace _06.SearchForReviewers
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            string xPathQuery = "/review-queries/query";

            XmlNodeList bookList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in bookList)
            {
                XmlAttribute attrByDate = bookNode.Attributes["type"];

                List<Review> searchedReview = new List<Review>();

                if (attrByDate != null)
                {
                    if (attrByDate.InnerText == "by-period")
                    {
                        string startDate = GetChildText(bookNode, "start-date");
                        string endDate = GetChildText(bookNode, "end-date");
                        searchedReview = BookstoreDAL.FindByDate(startDate, endDate);
                        

                    }
                    else
                    {
                        string authorName = GetChildText(bookNode, "author-name");

                        searchedReview = BookstoreDAL.FindByAuther(authorName);
                        // don forget null
                    }
                }

            }
        }

        static string GetChildText(XmlNode node, string xpath)
        {
            XmlNode innerNode = node.SelectSingleNode(xpath);

            if (innerNode == null)
            {
                return null;
            }
            else
            {
                return innerNode.InnerText.Trim();
            }
        }

       
    }
}
