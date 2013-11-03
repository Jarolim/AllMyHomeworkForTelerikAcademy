using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Xml;

namespace BookstoreDB.Data
{
    public class BookstoreDAL
    {
        public static void AddBookInDB(string author, string title, string isbn, string price, string site)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            BookstoreDBEntities context = new BookstoreDBEntities();
            using (context)
            {
                Book book = new Book();
                if (isbn != null)
                {
                    book.ISBN = long.Parse(isbn);
                }
                else
                {
                    book.ISBN = null;
                }

                if (price != null)
                {
                    book.Price = decimal.Parse(price);
                }
                else
                {
                    book.Price = null;
                }

                book.WebSite = site;


                book.Title = title.ToLower();

                context.Books.Add(book);
                context.SaveChanges();

                // is author in the db
                var existingAuthor =
                (from a in context.Authors
                 where a.Name == author.ToLower()
                 select a).FirstOrDefault();

                if (existingAuthor == null)
                {
                    Author newAuthor = new Author()
                    {
                        Name = author.ToLower(),
                    };

                    context.Authors.Add(newAuthor);
                    context.SaveChanges();

                    existingAuthor = newAuthor;
                }

                book.Authors.Add(existingAuthor);
                context.SaveChanges();
            }
        }

        public static void AddComplexInDB(List<string[]> author, string title, string isbn, string price, string site,
            List<string[]> reviews)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            BookstoreDBEntities context = new BookstoreDBEntities();

            using (context)
            {
                List<Author> allAuthors = AddAuthors(context, author);
                List<Review> allReviews = AddReviews(context, reviews);

                Book book = new Book();
                if (isbn != null)
                {
                    book.ISBN = long.Parse(isbn);
                }
                else
                {
                    book.ISBN = null;
                }

                if (price != null)
                {
                    book.Price = decimal.Parse(price);
                }
                else
                {
                    book.Price = null;
                }

                book.WebSite = site;

                book.Title = title.ToLower();

                context.Books.Add(book);
                context.SaveChanges();

                // is author in the db

                foreach (var a in allAuthors)
                {
                    book.Authors.Add(a);
                    context.SaveChanges();
                }

                foreach (var r in allReviews)
                {
                    book.Reviews.Add(r);
                    context.Reviews.Add(r);
                    context.SaveChanges();
                }
            }
        }

        private static List<Author> AddAuthors(BookstoreDBEntities context, List<string[]> authors)
        {
            List<Author> authorList = new List<Author>();

            if (authorList == null)
            {
                return null;
            }

            foreach (var author in authors)
            {
                string autherName = author[0].ToLower();

                var existingAuthor =
               (from a in context.Authors
                where a.Name == autherName
                select a).FirstOrDefault();

                if (existingAuthor == null)
                {
                    Author newAuthor = new Author()
                    {
                        Name = author[0].ToLower(),
                    };

                    context.Authors.Add(newAuthor);
                    context.SaveChanges();

                    existingAuthor = newAuthor;
                }

                authorList.Add(existingAuthor);
            }

            return authorList;
        }

        private static List<Review> AddReviews(BookstoreDBEntities context, List<string[]> reviews)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            List<Review> allReviews = new List<Review>();

            if (reviews == null)
            {
                return null;
            }

            foreach (var rev in reviews)
            {
                Review review = new Review();

                review.Text = rev[0];

                if (rev[2] != null)
                {
                    review.CreationDate = DateTime.ParseExact(rev[2], "d-MMM-yyyy", provider);
                }
                else
                {
                    review.CreationDate = null;
                }

                if (rev[1] != null)
                {
                    string name = rev[1].ToLower();

                    var existingAuthor =
                      (from a in context.Authors
                       where a.Name == name
                       select a).FirstOrDefault();
                    //IMPORTANT
                    // I am not very sure is the auther of the review is missing from the database what I must do
                    // so if we must create ne and attach him to the review just uncomment this code or if only 
                    // existing authors must be attached do nothing :)
                    // thanks
                    //---------------------------------
                    if (existingAuthor == null)
                    {
                        Author newAuthor = new Author()
                        {
                            Name = rev[1].ToLower(),
                        };

                        context.Authors.Add(newAuthor);
                        context.SaveChanges();

                        existingAuthor = newAuthor;
                    }
                    //----------------------------------
                    review.Author = existingAuthor;
                }
                else
                {
                    review.Author = null;
                }

                allReviews.Add(review);
            }

            return allReviews;
        }

        public static void SimpleSearch(string title, string auther, string isbn)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            BookstoreDBEntities context = new BookstoreDBEntities();
            using (context)
            {
                var book =
                from b in context.Books
                select b;

                if (title != null)
                {
                    title = title.ToLower();
                    book =
                        from a in context.Books
                        where a.Title == title
                        select a;
                }

                if (isbn != null)
                {
                    isbn = isbn.Trim();
                    long? myisbn = long.Parse(isbn);
                    book = book.Where(b => b.ISBN == myisbn);
                }

                if (auther != null)
                {
                    auther = auther.ToLower().Trim();
                    book = book.Where(
                        b => b.Authors.Any(t => t.Name == auther));
                }

                book = book.OrderBy(b => b.Title);

                List<Book> allBooks = book.ToList();

                int count = allBooks.Count;
                if (count == 0)
                {
                    Console.WriteLine("Nothing found");
                }
                else
                {
                    Console.WriteLine("{0} books found:", count);
                }

                foreach (var item in book)
                {
                    var reviewers =
                        (from x in context.Books
                        where x.Title == item.Title
                        select x.Reviews.Count).First();

                    if ((int)reviewers > 0)
                    {
                        Console.WriteLine("{0} --> {1} reviews", item.Title, reviewers);
                    }
                    else
                    {
                        Console.WriteLine("{0} --> no reviews", item.Title);
                    }
                }
            }
        }

        public static List<Review> FindByDate(string startDateAsString, string endDateAsString)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime? startDate = DateTime.ParseExact(startDateAsString,"dd-MMM-yyyy",provider);
            DateTime? endDate = DateTime.ParseExact(endDateAsString,"dd-MMM-yyyy",provider);

            using (context)
            {
                var rev =
                    (from r in context.Reviews
                    where r.CreationDate >= startDate && r.CreationDate <= endDate
                    select r).OrderBy(x => x.CreationDate).ThenBy(y => y.Text);
                
                WritingResults(rev.ToList());
              return  rev.ToList();
            }
        }

        public static List<Review> FindByAuther(string autherName)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();

            using (context)
            {
                var rev =
                    (from r in context.Reviews
                    where r.Author.Name == autherName
                     select r).OrderBy(x => x.CreationDate);
                
                return rev.ToList();
            }
        }
        /// <summary>
        /// It is working onli with one tag 
        /// </summary>
        /// <param name="list"></param>
        static void WritingResults(List<Review> list)
        {
            //BookstoreDBEntities context = new BookstoreDBEntities();
            string fileName = "../../reviews-search-results.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                foreach (var item in list)
                {
                    writer.WriteStartElement("result-set");
                    writer.WriteStartElement("review");
                    writer.WriteStartElement("date");
                    writer.WriteString(item.CreationDate.ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("content");
                    writer.WriteString(item.Text.ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("book");
                    if (item.Book.Title != null)
                    {
                        writer.WriteStartElement("title");
                        writer.WriteString(item.Book.Title.ToString());
                        writer.WriteEndElement();
                    }
                    if (item.Book.Authors != null)
                    {
                        writer.WriteStartElement("authors");
                        foreach (var a in item.Book.Authors)
                        {
                            writer.WriteString(a.Name + ", ");
                        }
                        writer.WriteString(item.Book.Title.ToString());
                        writer.WriteEndElement();
                    }
                    if (item.Book.ISBN != null)
                    {
                        writer.WriteStartElement("isbn");
                        writer.WriteString(item.Book.ISBN.ToString());
                        writer.WriteEndElement();
                    }
                    if (item.Book.WebSite != null)
                    {
                        writer.WriteStartElement("url");
                        writer.WriteString(item.Book.WebSite);
                        
                    }

                  
                    
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                   // writer.WriteEndElement();
                }

            }
            Console.WriteLine("Document {0} created.", fileName);
        }
    }
}
