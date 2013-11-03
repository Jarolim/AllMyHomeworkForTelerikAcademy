using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreDB.Data;
using System.Transactions;
using System.Xml;

namespace _05.SimpleSearchForBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string xPathQuery = "/query";

            XmlNodeList bookList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in bookList)
            {
                string title = GetChildText(bookNode, "title");
                string author = GetChildText(bookNode, "author");
                string isbn = GetChildText(bookNode, "isbn");

                BookstoreDAL.SimpleSearch(title, author, isbn);
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
