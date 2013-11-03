using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Utility;
using Bookstore.Models;


namespace ComplexSearch
{
    public class ComplexSearcher
    {
        const string Author = "author";
        const string StartDate = "start-date";
        const string EndDate = "end-date";

        const string QueryType = "type";
        const string ByPeriod = "by-period";
        const string ByAuthor = "by-author";

        const string ResultsFile = @"..\..\reviews-search-results.xml";
        const string Query = @"..\..\reviews-queries.xml";
        const string EncodingType = "windows-1251";

        static void Main()
        {
            var xmlSearch = new System.Xml.XmlDocument();

            xmlSearch.Load(Query);

            var query = xmlSearch.SelectNodes("/review-queries/query");

            foreach (XmlNode node in query)
            {
                var type = node.Attributes[QueryType].GetText();
                
                var startDate = node[StartDate].GetText();
                var endDate = node[EndDate].GetText();

                var author = node[Author].GetText();

                ValidateQuery(type, startDate, endDate, author);
                                
                Encoding encoding = Encoding.GetEncoding(EncodingType);

                using (XmlTextWriter writer = new XmlTextWriter(ResultsFile, encoding))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    var reviewsFound = BookstoreDAO.FindReviews(type, startDate, endDate, author);

                    writer.WriteStartDocument();
                    writer.WriteStartElement("search-results");
                    if (reviewsFound.Count > 0)
                    {
                        foreach (var review in reviewsFound)
                        {
                            WriteReviewElement(review, writer);
                        }
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

            }
            
        }

        private static void WriteReviewElement(Review review, XmlTextWriter writer)
        {
            writer.WriteStartElement("result-set");
            if (review.CreationDate != null)
            {
                writer.WriteElementString("data", review.CreationDate.ToString());
            }

            writer.WriteElementString("content", review.Text);

            writer.WriteStartElement("book");
            writer.WriteElementString("title", review.Book.Title);
            if (review.Book.Authors != null && review.Book.Authors.Count > 0)
            {
                writer.WriteElementString("authors", string.Join(", ",review.Book.Authors));
            }

            if (review.Book.ISBN != null)
	        {
		         writer.WriteElementString("isbn", review.Book.ISBN);
	        }

            if (review.Book.WebSite != null)
	        {
		         writer.WriteElementString("url", review.Book.WebSite);
	        }

            writer.WriteEndElement();
        }

        private static void ValidateQuery(string type, string startDate, string endDate, string author)
        {
            if (type == ByPeriod)
            {
                if (startDate == null || endDate == null)
                {
                    throw new ArgumentException("Start and end dates are mandatory when searching by period");
                }
            }
            else if (type == ByAuthor && author == null)
            {
                throw new ArgumentException("Author is mandatory when searching by author");
            }
        }
    }
}
