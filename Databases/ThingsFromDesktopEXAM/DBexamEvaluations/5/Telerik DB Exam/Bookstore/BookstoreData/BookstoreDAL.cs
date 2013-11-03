using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionsLibrary;

namespace BookstoreData
{
    public static class BookstoreDAL
    {
        public static List<Review> FinReviewsByAuhtor(string authorName, BookstoreEntities dbContext)
        {
            List<Review> reviews = dbContext.Reviews.Where(r => r.Book.Authors.Any(a => a.Name == authorName)).ToList();
            return reviews;
        }

        public static List<Review> FinReviewsByDate(DateTime startDate, DateTime endDate, BookstoreEntities dbContext)
        {
            List<Review> reviews = dbContext.Reviews.Where(r => r.Creation_Date >= startDate && r.Creation_Date <= endDate).ToList();
            return reviews;
        }

        public static List<Book> SimpleSearch(string title, string author, string isbn)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                //Create query
                IQueryable<Book> booksFound = dbContext.Books;

                if (title != null)
                {
                    booksFound = booksFound.Where(b => b.Title.ToLower() == title.ToLower());
                }

                if (isbn != null)
                {
                    long isbnNumber = long.Parse(isbn);
                    booksFound = booksFound.Where(b => b.ISBN == isbnNumber);
                }

                if (author != null)
                {
                    booksFound = booksFound.Where(b => b.Authors.Any(a => a.Name.ToLower() == author));
                }

                //Order result
                booksFound = booksFound.OrderBy(b => b.Title);

                //Return list of SimpleBookInfo objects
                return booksFound.ToList();
            }
        }

        public static void AddBookComplex(string title, List<string> authors, long? isbn, decimal? price, string webSite, List<ReviewStruct> reviews)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                //Create authors
                List<Author> bookAuthors = new List<Author>();
                foreach (var authorName in authors)
                {
                    Author author = CreateOrLoadAuthor(authorName, dbContext);
                    bookAuthors.Add(author);
                }

                //Create reviews
                List<Review> bookReviews = new List<Review>();
                foreach (var reviewInfo in reviews)
                {
                    Review review = new Review();
                    if (reviewInfo.AuthorName != null)
                    {
                        review.Author = CreateOrLoadAuthor(reviewInfo.AuthorName, dbContext);
                    }
                    review.Creation_Date = reviewInfo.CreationDate;
                    review.Text = reviewInfo.Text;

                    bookReviews.Add(review);
                }

                CheckIsbnUniqueness(isbn, dbContext);

                //Create book
                Book newBook = new Book() { Title = title, ISBN = isbn, Price = price, Web_Site = webSite };
                foreach (var author in bookAuthors)
                {
                    newBook.Authors.Add(author);
                }

                foreach (var review in bookReviews)
                {
                    newBook.Reviews.Add(review);
                }

                //Save book
                dbContext.Books.Add(newBook);
                dbContext.SaveChanges();
            }
        }

        public static void AddBook(string title, string authorName, long? isbn, decimal? price)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                Author author = CreateOrLoadAuthor(authorName, dbContext);
                CheckIsbnUniqueness(isbn, dbContext);

                Book newBook = new Book() { Title = title, ISBN = isbn, Price = price };
                newBook.Authors.Add(author);

                dbContext.Books.Add(newBook);
                dbContext.SaveChanges();
            }
        }

        public static int GetReviewCount(int bookId)
        {
            using (BookstoreEntities dbContext = new BookstoreEntities())
            {
                int reviewCount = 0;
                Book book = dbContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();
                if (book != null)
                {
                    reviewCount = book.Reviews.Count;
                }

                return reviewCount;
            }
        }

        private static void CheckIsbnUniqueness(long? isbn, BookstoreEntities dbContext)
        {
            Book book = dbContext.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                throw new DuplicateIsbnException(String.Format("Book with isbn {0} already exists", isbn));
            }
        }

        private static Author CreateOrLoadAuthor(string authorName, BookstoreEntities dbContext)
        {
            Author author = dbContext.Authors.FirstOrDefault(a => a.Name == authorName);

            if (author == null)
            {
                author = new Author() { Name = authorName };
            }

            dbContext.SaveChanges();
            return author;
        }
    }

    public struct ReviewStruct
    {
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
