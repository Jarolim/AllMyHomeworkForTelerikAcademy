using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Xml;
using BookstoreData;

namespace ComlexBooksImporter
{
    static class ComlexBooksImporter
    {
        static void Main()
        {
            TransactionScope tran =	new TransactionScope(
			TransactionScopeOption.Required,
				new TransactionOptions() {
					IsolationLevel = IsolationLevel.RepeatableRead });
            using (tran)
            {
                //Open xml file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../complex-books.xml");

                //Create query to xml file
                string xPathQuery = "/catalog/book";
                XmlNodeList bookList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode bookNode in bookList)
                {
                    //Parse authors
                    List<string> authors = new List<string>();
                    XmlNode authorNodesList = bookNode.SelectSingleNode("authors");
                    if (authorNodesList != null)
                    {
                        foreach (XmlNode authorNode in authorNodesList.SelectNodes("author"))
                        {
                            string author = authorNode.InnerText.Trim();
                            authors.Add(author);
                        }
                    }

                    //Parse title
                    string title = bookNode.GetChildText("title");
                    ArgumentExceptionThrower(title, "title");

                    //Parse ISBN
                    string isbnAsString = bookNode.GetChildText("isbn");
                    long? isbn = (isbnAsString != null) ? long.Parse(isbnAsString) : (long?)null;

                    //Parse Price
                    string priceAsString = bookNode.GetChildText("price");
                    decimal? price = (priceAsString != null) ? decimal.Parse(priceAsString) : (decimal?)null;
                    
                    //Parse web site
                    string webSite = bookNode.GetChildText("web-site");

                    //Parse reviews
                    List<ReviewStruct> reviews = new List<ReviewStruct>();
                    XmlNode reviewNodesList = bookNode.SelectSingleNode("reviews");
                    if (reviewNodesList != null)
                    {
                        foreach (XmlNode reviewNode in reviewNodesList.SelectNodes("review"))
                        {
                            ReviewStruct review = new ReviewStruct();
                            review.Text = reviewNode.InnerText.Trim();
                            var reviewAttributeAuthor = reviewNode.Attributes["author"];
                            if (reviewAttributeAuthor != null)
                            {
                                review.AuthorName = reviewAttributeAuthor.Value;
                            }

                            var reviewAttributeDate = reviewNode.Attributes["date"];
                            if (reviewAttributeDate != null)
                            {
                                review.CreationDate = DateTime.Parse(reviewAttributeDate.Value);
                            }
                            else
                            {
                                review.CreationDate = DateTime.Now;
                            }

                            reviews.Add(review);
                        }
                    }
                    //Save the book in Bookstore database
                    BookstoreDAL.AddBookComplex(title, authors, isbn, price,webSite, reviews);
                }
                tran.Complete();
            }
            
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }

        private static void ArgumentExceptionThrower(object o, string missingParameter)
        {
            if (o == null)
            {
                throw new ArgumentNullException(missingParameter);
            }
        }
    }
}