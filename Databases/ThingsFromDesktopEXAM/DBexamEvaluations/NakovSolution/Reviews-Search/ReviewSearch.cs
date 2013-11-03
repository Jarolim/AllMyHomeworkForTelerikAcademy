using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using Bookstore.Data;
using Bookstore.Logs;

static class ReviewSearch
{
	static void Main()
	{
		using (XmlTextWriter writer = new XmlTextWriter(
			"../../reviews-search-results.xml", Encoding.UTF8))
		{
			writer.Formatting = Formatting.Indented;
			writer.IndentChar = '\t';
			writer.Indentation = 1;

			writer.WriteStartDocument();
			writer.WriteStartElement("search-results");

			ProcessSearchQueries(writer);

			writer.WriteEndDocument();
		}			
	}

	private static void ProcessSearchQueries(XmlTextWriter writer)
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load("../../reviews-queries.xml");
		XmlNodeList queryNodes = xmlDoc.SelectNodes("/review-queries/query");
		foreach (XmlNode queryNode in queryNodes)
		{
			string queryType = queryNode.Attributes["type"].Value;
			if (queryType == "by-period")
			{
				ProcessQueryByPeriod(writer, queryNode);
			}
			else if (queryType == "by-author")
			{
				ProcessQueryByAuthor(writer, queryNode);
			}
			else
			{
				throw new InvalidOperationException("Invalid query type: " + queryType);
			}
			LogsContext.AppendToSearchLogs(queryNode.OuterXml);
		}
	}

	private static void ProcessQueryByAuthor(XmlTextWriter writer, XmlNode queryNode)
	{
		string reviewAuthorName = queryNode.GetChildText("author-name");
		IList<Review> reviews = BookstoreDAL.FindReviews(reviewAuthorName);
		PrintReviews(writer, reviews);
	}

	private static void ProcessQueryByPeriod(XmlTextWriter writer, XmlNode queryNode)
	{
		string startDateStr = queryNode.GetChildText("start-date");
		DateTime startDate = DateTime.ParseExact(
			startDateStr, Constants.DATE_FORMAT, Constants.DEFAULT_CULTURE);
		string endDateStr = queryNode.GetChildText("end-date");
		DateTime endDate = DateTime.ParseExact(
			endDateStr, Constants.DATE_FORMAT, Constants.DEFAULT_CULTURE);
		IList<Review> reviews = BookstoreDAL.FindReviews(startDate, endDate);
		PrintReviews(writer, reviews);
	}

	public static void PrintReviews(XmlTextWriter writer, IList<Review> reviews)
	{
		writer.WriteStartElement("result-set");
		foreach (var review in reviews)
		{
			writer.WriteStartElement("review");
			string dateStr = review.Date.ToString(
				Constants.DATE_FORMAT, Constants.DEFAULT_CULTURE);
			writer.WriteElementString("date", dateStr);
			writer.WriteElementString("content", review.Content);

			Book book = review.Book;
			writer.WriteStartElement("book");
			writer.WriteElementString("title", book.Title);
			if (book.Authors.Count > 0)
			{
				string bookAuthors = string.Join(", ", 
					book.Authors.OrderBy(a => a.Name).Select(a => a.Name));
				writer.WriteElementString("authors", bookAuthors);
			}
			if (book.ISBN != null)
			{
				writer.WriteElementString("isbn", book.ISBN);
			}
			if (book.Url != null)
			{
				writer.WriteElementString("url", book.Url);
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}	
}
