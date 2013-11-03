using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Xml;
using Bookstore.Data;

class SimpleBooksImporter
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = Constants.DEFAULT_CULTURE;

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load("../../simple-books.xml");
		XmlNodeList booksList = xmlDoc.SelectNodes("/catalog/book");
		foreach (XmlNode bookNode in booksList)
		{
			string title = bookNode.GetChildText("title");
			string author = bookNode.GetChildText("author");
			string priceStr = bookNode.GetChildText("price");
			decimal? price = null;
			if (priceStr != null)
			{
				price = decimal.Parse(priceStr);
			}
			string isbn = bookNode.GetChildText("isbn");
			string url = bookNode.GetChildText("web-site");
			TransactionScope tran = new TransactionScope(TransactionScopeOption.Required,
				new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead });
			using (tran)
			{
				BookstoreDAL.AddBook(title, author, price, isbn, url);
				tran.Complete();
			}
		}
	}
}
