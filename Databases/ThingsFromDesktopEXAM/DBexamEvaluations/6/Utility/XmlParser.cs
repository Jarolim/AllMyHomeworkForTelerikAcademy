using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
//using Bookstore.DbModels;

namespace Utility
{
    public static class XmlParser
    {
        const string Title = "title";
        const string Author = "author";
        const string Authors = "authors";      
        const string ISBN = "isbn";
        const string Website = "web-site";
        const string Price = "price";
        const string Reviews = "reviews";
        const string Review = "review";
        const string Date = "date";

        const int ISBNLength = 13;

        public static List<NewBook> ParseXmlBooks(XmlNodeList books, bool complex = false)
        {
            var newBooks = new List<NewBook>();

            foreach (XmlNode book in books)
            {
                var website = book[Website].GetText();
                var isbn = book[ISBN].GetText();
                var title = book[Title].GetText();

                var price = book[Price].GetText();
                decimal? decimalPrice = ParsePrice(price);

                var reviews = book[Reviews];
                var parsedReviews = ParseReviews(reviews);
               
                newBooks.Add(new NewBook
                {
                    Authors = ParseAuthors(book, complex),
                    Title = title,
                    WebSite = website,
                    ISBN = isbn,
                    Price = decimalPrice,
                    Reviews = parsedReviews
                });
            }

            return newBooks;
        }

        private static ICollection<Review> ParseReviews(XmlElement reviews)
        {
            if (reviews == null)
            {
                return null;
            }

            var parsedReviews = new List<Review>();

            foreach (XmlNode review in reviews)
            {
                var newReview = ParseReview(review);
                parsedReviews.Add(newReview);
            }

            return parsedReviews;
        }

        private static Review ParseReview(XmlNode review)
        {
            var newReview = new Review
            {                
                Text = review.GetText()
            };

            var authorText = review.Attributes[Author].GetText();
            if (authorText != null)
	        {
                newReview.Author = new Author { Name = authorText };
	        }                       

            var dateString = review.Attributes[Date].GetText();
            var parsedDate = ParseDate(dateString);

            if (parsedDate != null)
            {
                newReview.CreationDate = DateTime.Parse(parsedDate.ToString());
            }

            return newReview;
        }

        private static DateTime? ParseDate(string dateString)
        {
            if (dateString == null)
            {
                return null;
            }

            var date = new DateTime();

            DateTime.TryParse(dateString, out date);

            return date;
        }

        private static ICollection<Author> ParseAuthors(XmlNode book, bool complex)
        {
            var author = book[Author];
            var authors = book[Authors];
            
            if (complex && author == null && authors == null)
            {
                return null;
            }

            var authorsList = new List<Author>();
            if (author != null)
            {
                authorsList.Add(new Author { Name = author.GetText() });
            }

            if (authors != null)
            {
                foreach (XmlNode auth in authors)
                {
                    authorsList.Add(new Author { Name = auth.GetText()});
                }
            }

            return authorsList;
        }

        private static decimal? ParsePrice(string price)
        {
            decimal? decimalPrice = null;
            if (price != null)
            {
                decimalPrice = decimal.Parse(price);
            }
            return decimalPrice;
        }

        #region Validation methods
        public static void ValidateBooks(XmlNodeList books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                ValidateAuthorTitle(books, i);

                ValidateISBN(books, i);

                ValidatePrice(books, i);
            }
        }

        private static void ValidatePrice(XmlNodeList books, int i)
        {
            var price = books[i]["price"].GetText();

            if (price != null)
            {
                var decimalPrice = 0m;

                if (!decimal.TryParse(price, out decimalPrice))
                {
                    throw new ArgumentException("If specified price should be of kind 00000.00!" +
                        " Can be left null if unknown!");
                }
            }
        }

        private static void ValidateAuthorTitle(XmlNodeList books, int i)
        {

            var title = books[i]["title"];
            var author = books[i]["author"];
            var authors = books[i]["authors"];

            if (title == null || author == null && authors == null)
            {
                throw new ArgumentNullException("Author(s) or Title",
                    "Author(s) and title of a book to e inserted are not allowed to be null!");
            }
        }

        private static void ValidateISBN(XmlNodeList books, int i)
        {
            var isbn = books[i]["isbn"].GetText();
            if (isbn != null)
            {
                var hasNonDigitSymbols = Regex.Match(isbn, @"\D").Success;

                var lenght = isbn.Length;
                if (hasNonDigitSymbols || lenght != 13)
                {
                    throw new ArgumentException(string.Format("ISBN can not contain non-digits and " +
                        "can not have length other than {0}. It can be left null if unknown.", ISBNLength));
                }
            }
        }
        #endregion
    }
}
