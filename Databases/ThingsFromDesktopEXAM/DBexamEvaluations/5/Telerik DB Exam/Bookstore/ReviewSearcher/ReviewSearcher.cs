using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using BookstoreData;
using SearchLogsData;
using System.Data.Entity;

namespace ReviewSearcher
{
    public static class ReviewSearcher
    {
        static void Main()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LogEntities>());
            using (XmlTextWriter xmlWriter = new XmlTextWriter("../../reviews-search-results.xml", Encoding.UTF8))
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.IndentChar = '\t';
                xmlWriter.Indentation = 1;

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("search-results");

                //Find reviews and render them to xmlWriter
                PerformSearch(xmlWriter);

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        private static void PerformSearch(XmlTextWriter xmlWriter)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                //Open xml file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../reviews-queries.xml");

                //Create query to xml file
                string xPathQuery = "/review-queries/query";
                XmlNodeList queryList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode queryNode in queryList)
                {
                    //***Save query to Logs - task 7***
                    SaveQueryToLogs(queryNode.OuterXml);

                    //Find reviews for current query
                    List<Review> reviewsFound = new List<Review>();
                    string type = queryNode.Attributes["type"].Value;
                    if (type == "by-period")
                    {
                        DateTime startDate = DateTime.Parse(queryNode.SelectSingleNode("start-date").InnerText);
                        DateTime endDate = DateTime.Parse(queryNode.SelectSingleNode("end-date").InnerText);
                        reviewsFound = BookstoreDAL.FinReviewsByDate(startDate, endDate, dbContext);
                    }
                    else
                    {
                        string authorName = queryNode.SelectSingleNode("author-name").InnerText;
                        reviewsFound = BookstoreDAL.FinReviewsByAuhtor(authorName, dbContext);
                    }

                    //Sort the reviews 
                    var reviewsToRender = reviewsFound.OrderBy(r => r.Creation_Date).ThenBy(r => r.Text).ToList();

                    //Render reviews for current query
                    RenderReviewsToXml(reviewsToRender, xmlWriter, dbContext);
                }
            }
        }
  
        //Task 7 - Log all queries
        private static void SaveQueryToLogs(string outerXml)
        {
            using (LogEntities context = new LogEntities())
            {
                SearchLogsData.SearchLog log = new SearchLog() { Date = DateTime.Now, QueryXml = outerXml };
                context.SearchLogs.Add(log);
                context.SaveChanges();
            }
        }
  
        //Creating a single result-set in the output xml file
        private static void RenderReviewsToXml(IList<Review> reviewsToRender, XmlTextWriter xmlWriter, BookstoreEntities dbContext)
        {
            xmlWriter.WriteStartElement("result-set");
            foreach (var review in reviewsToRender)
            {
                xmlWriter.WriteStartElement("review");
                xmlWriter.WriteElementString("date", String.Format("{0:dd-MMM-yyyy}", review.Creation_Date));
                xmlWriter.WriteElementString("content", review.Text);
                xmlWriter.WriteStartElement("book");
                Book book = review.Book;
                xmlWriter.WriteElementString("title", book.Title);

                if (book.Authors.Count > 0)
                {
                    xmlWriter.WriteElementString("authors", string.Join(", ", book.Authors.Select(a => a.Name).OrderBy(n => n).ToList()));
                }

                if (book.ISBN != null)
                {
                    xmlWriter.WriteElementString("isbn", book.ISBN.ToString());
                }

                if (book.Web_Site != null)
                {
                    xmlWriter.WriteElementString("url", book.Web_Site);
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
        }
    }
}
