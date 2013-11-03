using System;
using System.Linq;
using System.Xml;
using BookStore.Model;
using System.Transactions;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Client
{
    public static class Program
    {
        private static BookStoreEntities context = new BookStoreEntities();
        static void Main(string[] args)
        {
            //SimpleBooksImport();
            //ComplexBooksImport();
           //SimpleBookSearch();
            ComplexReviewSearch();
        }

        public static void SimpleBooksImport()
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

                XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode bookNode in booksList)
                {
                    string author = bookNode.GetChildText("author");
                    string title = bookNode.GetChildText("title");
                    string isbn = bookNode.GetChildText("isbn");
                    decimal price;
                    bool isNull = decimal.TryParse(bookNode.GetChildText("price"), out price);
                    string website = bookNode.GetChildText("web-site");

                    if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title))
                    {
                        throw new ArgumentException("Required field is missing");
                    }

                    AddBook(new List<string>(){author}, title, isbn, price, website);

                    Thread.Sleep(500);

                }

                tran.Complete();
            }
        }

        public static void ComplexBooksImport()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../complex-books.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in booksList)
            {

                TransactionScope tran = new TransactionScope(
                TransactionScopeOption.Required,
                    new TransactionOptions()
                    {
                        IsolationLevel = IsolationLevel.RepeatableRead
                    });

                using (tran)
                {
                    XmlNodeList authorsList = bookNode.SelectNodes("authors/author");
                    List<string> authors = new List<string>();

                    foreach (XmlNode authorNode in authorsList)
                    {
                        string authorName = authorNode.InnerText;
                        authors.Add(authorName);
                    }


                    XmlNodeList reviewsList = bookNode.SelectNodes("reviews");
                    List<Review> reviews = new List<Review>();
                    foreach (XmlNode reviewsNode in reviewsList)
                    {
                        XmlNodeList reviewNode = reviewsNode.SelectNodes("review");
                        foreach (XmlNode review in reviewNode)
                        {
                            Review newReview = new Review();
                            newReview.Text = review.InnerText;

                            string date = null;
                            string authorName = null;
                            try
                            {
                                date = review.Attributes["date"].InnerText;
                                authorName = review.Attributes["author"].InnerText;
                            }
                            catch (Exception)
                            {
                            }

                            if (string.IsNullOrEmpty(date))
                            {
                                newReview.Date = DateTime.Now;
                            }
                            else
                            {
                                newReview.Date = DateTime.Parse(date);
                            }

                            newReview.Author = GetOrCreateAuthor(authorName, new BookStoreEntities());

                            reviews.Add(newReview);
                        }
                    }

                    string title = bookNode.GetChildText("title");
                    string isbn = bookNode.GetChildText("isbn");
                    decimal price;
                    bool isNull = decimal.TryParse(bookNode.GetChildText("price"), out price);
                    string website = bookNode.GetChildText("web-site");

                    AddBook(authors, reviews, title, isbn, price, website);

                    Thread.Sleep(500);
                    tran.Complete();
                }
                
            }
        }

        public static void SimpleBookSearch()
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
                xmlDoc.Load("../../simple-query.xml");
                string xPathQuery = "/query";

                XmlNodeList query = xmlDoc.SelectNodes(xPathQuery);
                foreach (XmlNode queryParameter in query)
                {
                    string title = queryParameter.GetChildText("title");
                    string authorName = queryParameter.GetChildText("author");
                    string isbn = queryParameter.GetChildText("isbn");

                    FindBook(title, authorName, isbn);
                    Thread.Sleep(500);

                }

                tran.Complete();
            }
        }

        public static void ComplexReviewSearch()
        {
            string fileName = "../../search-results.xml";
            using (XmlTextWriter writer =
                new XmlTextWriter(fileName, Encoding.UTF8))
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

        private static void ProcessSearchQueries(XmlWriter writer)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../reviews-queries.xml");
            foreach (XmlNode query in xmlDoc.SelectNodes("/review-queries/query"))
            {
                string typeAttribute = query.Attributes["type"].InnerText;
                if (typeAttribute == "by-period")
                {
                    DateTime startDate = DateTime.Parse(query.GetChildText("start-date"));
                    DateTime endDate = DateTime.Parse(query.GetChildText("end-date"));
                    FindReviewsByPeriod(startDate, endDate, writer);
                }
                else
                {
                    string authorName = query.GetChildText("author-name");
                    FindByAuthor(authorName, writer);
                }
            }		
        }

        private static void FindReviewsByPeriod(DateTime start, DateTime end, XmlWriter writer)
        {
            var reviews = context.Reviews.Where(x => x.Date >= start && x.Date <= end).OrderBy(x => x.Date).ThenBy(x => x.Text);
            writer.WriteStartElement("result-set");

            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                    writer.WriteElementString("date", review.Date.ToShortDateString());
                    writer.WriteElementString("content", review.Text);
                    writer.WriteStartElement("book");
                        string authors = "";
                        foreach (var item in review.Book.Authors)
                        {
                            authors += item.FullName + ",";
                        }

                        if (!string.IsNullOrEmpty(authors))
                        {
                            writer.WriteElementString("authors", authors);
                        }

                        writer.WriteElementString("title", review.Book.Title);
                        if (review.Book.ISBN != null)
                        {
                            writer.WriteElementString("ISBN", review.Book.ISBN);
                        }
                        if (review.Book.Price != null)
                        {
                            writer.WriteElementString("price", review.Book.Price.ToString());
                        }
                        if (review.Book.Website != null)
                        {
                            writer.WriteElementString("price", review.Book.Website);
                        }
                    writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static void FindByAuthor(string authorName, XmlWriter writer)
        {
            var reviews = context.Reviews.Where(x => x.Author.FullName.ToLower() == authorName.ToLower()).OrderBy(x => x.Date).ThenBy(x => x.Text);
            writer.WriteStartElement("result-set");
            foreach (var review in reviews)
            {
                writer.WriteStartElement("review");
                writer.WriteElementString("date", review.Date.ToShortDateString());
                writer.WriteElementString("content", review.Text);
                writer.WriteStartElement("book");
                string authors = "";
                foreach (var item in review.Book.Authors)
                {
                    authors += item.FullName + ",";
                }

                if (!string.IsNullOrEmpty(authors))
                {
                    writer.WriteElementString("authors", authors);
                }

                writer.WriteElementString("title", review.Book.Title);
                if (review.Book.ISBN != null)
                {
                    writer.WriteElementString("ISBN", review.Book.ISBN);
                }
                if (review.Book.Price != null)
                {
                    writer.WriteElementString("price", review.Book.Price.ToString());
                }
                if (review.Book.Website != null)
                {
                    writer.WriteElementString("price", review.Book.Website);
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        private static void FindBook(string title, string authorName, string isbn)
        {
            if (title == null && authorName == null && isbn == null)
            {
                Console.WriteLine("Nothing found!");
            }
            else
            {
                IEnumerable<Book> results = new List<Book>();

                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(
                        x => x.Title.ToLower() == title.ToLower() && x.Authors.Where(a => a.FullName.ToLower() == authorName.ToLower()).Count() > 0 &&
                            x.ISBN == isbn);
                }
                else if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(authorName) && string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(
                        x => x.Title.ToLower() == title.ToLower() && x.Authors.Where(a => a.FullName.ToLower() == authorName.ToLower()).Count() > 0);
                }
                else if (!string.IsNullOrEmpty(title) && string.IsNullOrEmpty(authorName) && string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(x => x.Title.ToLower() == title.ToLower());
                }
                else if (!string.IsNullOrEmpty(title) && string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(x => x.Title.ToLower() == title.ToLower() && x.ISBN == isbn);
                }
                else if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(x => x.ISBN == isbn);
                }
                else if (string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(authorName) && !string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(x => x.Authors.Where(a => a.FullName.ToLower() == authorName.ToLower()).Count() > 0 && x.ISBN == isbn);
                }
                else if (string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(authorName) && string.IsNullOrEmpty(isbn))
                {
                    results = context.Books.Where(x => x.Authors.Where(a => a.FullName.ToLower() == authorName.ToLower()).Count() > 0);
                }

                results = results.OrderBy(x => x.Title);
                if (results.Count() == 0)
                {
                    Console.WriteLine("Nothing found!");
                }
                foreach (var book in results)
                {
                    Console.WriteLine("{0} --------> {1} reviews", book.Title, book.Reviews.Count);
                }
            }
        }

        private static void AddBook(List<string> authorNames, string title, string isbn, decimal price, string website)
        {
            BookStoreEntities context = new BookStoreEntities();
            Book newBook = new Book()
            {
                Title = title,
                ISBN = isbn,
                Price = price,
                Website = website
            };


            foreach (var authorName in authorNames)
            {
                var authorInDB = GetOrCreateAuthor(authorName, context);
                newBook.Authors.Add(authorInDB);
            }

            context.Books.Add(newBook);
            if (newBook.Authors.Count == 0)
            {
                throw new ArgumentException("Author is required");
            }

            context.SaveChanges();
        }

        private static void AddBook(List<string> authorNames, List<Review> reviews, string title, string isbn, decimal price, string website)
        {
            Book newBook = new Book()
            {
                Title = title,
                ISBN = isbn,
                Price = price,
                Website = website
            };

            foreach (var authorName in authorNames)
            {
                var authorInDB = GetOrCreateAuthor(authorName, context);
                newBook.Authors.Add(authorInDB);
            }

            foreach (var item in reviews)
            {
                newBook.Reviews.Add(item);
            }

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        private static Author GetOrCreateAuthor(string authorName, BookStoreEntities context)
        {
            if (string.IsNullOrEmpty(authorName))
            {
                return null;
            }

            var authorInDB = context.Authors.Where(x => x.FullName.ToLower() == authorName.ToLower()).FirstOrDefault();

            if (authorInDB != null)
            {
                return authorInDB;
            }

            var newAuthor = new Author();
            newAuthor.FullName = authorName;
            
            return newAuthor;
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
    }
}
