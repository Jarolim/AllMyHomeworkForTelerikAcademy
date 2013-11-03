using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookstoreDB.Data;
using System.Transactions;
using System.Globalization;
using System.Threading;

namespace _04.ConmplexBookInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            TransactionScope tran = new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            });

            using (tran)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../complex-books.xml");
                string xPathQuery = "/catalog/book";

                XmlNodeList bookList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode book in bookList)
                {
                    List<string[]> authors = GetAllChildrenText(book, "authors/author");
                    List<string[]> reviews = GetAllChildrenText(book, "reviews/review");

                    string title = GetChildText(book, "title");
                    string isbn = GetChildText(book, "isbn");
                    string price = GetChildText(book, "price");
                    string site = GetChildText(book, "web-site");


                   
                    //string reviewDate = book.Attributes["date"].InnerText;

                    foreach (var author in authors)
                    {
                        //I change one of the tags in.xml because it will throw exepton here. The auther is obligatory
                        if (author == null)
                        {
                            throw new ArgumentNullException("Author is obligatory");
                        }
                    }

                    if (title == null)
                    {
                        throw new ArgumentNullException("Title is obligatory");
                    }

                    //Console.WriteLine("-------------------------");
                    //foreach (var a in authors)
                    //{
                    //    Console.WriteLine(a);
                    //}
                    //foreach (var r in reviews)
                    //{
                    //    Console.WriteLine("----r---" + r);
                    //}
                    //Console.WriteLine("\t\n{0}\t\n{1}\t\n{2}\t\n{3}", title, isbn, price, site);

                   BookstoreDAL.AddComplexInDB(authors, title, isbn, price, site, reviews);

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

        static List<string[]> GetAllChildrenText(XmlNode node, string xpath)
        {
            
            XmlNodeList innerNodeList = node.SelectNodes(xpath);
            List<string[]> list = new List<string[]>();

            if (innerNodeList == null)
            {
                return null;
            }
            else
            {
                foreach (XmlNode oneNode in innerNodeList)
                {
                    string[] attr = new string[3];

                    XmlAttribute rAutherAttr = oneNode.Attributes["author"];
                    string reviewAuthor = null;

                    if (rAutherAttr != null)
                    {
                        reviewAuthor = rAutherAttr.InnerText;
                    }

                    attr[1] = reviewAuthor;
                    XmlAttribute dateAttr = oneNode.Attributes["date"];
                    string reviewDate = null;
                    if (dateAttr != null)
                    {
                       // reviewDate = DateTime.ParseExact(dateAttr.InnerText, "dd-MMM-yyyy", provider);
                        reviewDate = dateAttr.InnerText;
                    }

                    attr[2] = reviewDate;
                    attr[0] = oneNode.InnerText.ToLower().Trim();
                    list.Add(attr);

                }

                return list;
            }  
        }
    }
}
