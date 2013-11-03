using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookstoreDB.Data;
using System.Transactions;

namespace Bookstore.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionScope tran = new TransactionScope(
        TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            });

            using (tran)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../simple-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList bookList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode book in bookList)
                {
                    string author = GetChildText(book, "author");
                    string title = GetChildText(book, "title");
                    string isbn = GetChildText(book, "isbn");
                    string price = GetChildText(book, "price");
                    string site = GetChildText(book, "web-site");

                    if (author == null)
                    {
                        throw new ArgumentNullException("Author is obligatory");
                    }
                    if (title == null)
                    {
                        throw new ArgumentNullException("Title is obligatory");
                    }

                    BookstoreDAL.AddBookInDB(author, title, isbn, price, site);

                }

                tran.Complete();
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
