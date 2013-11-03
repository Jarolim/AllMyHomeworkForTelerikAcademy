using System;
using System.Collections.Generic;
using System.Text;

namespace EShop
{
    public class Book : Product
    {
        //Fields:
        private string author;
        private int numberOfPages;
        private List<BooksGenres> genres;

        //Properties:
        public List<BooksGenres> Genres
        {
            get { return this.genres; }
            private set { this.genres = value; }
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter name of the book's author.");
                }
                this.author = value;
            }
        }

        public int NumberOfPages
        {
            get { return this.numberOfPages; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input! You should enter positive number for book pages.");
                }
                this.numberOfPages = value;
            }
        }

        //Constructors:
        public Book(string name, decimal price, string author, int numberOfPages, int productID, int quantity = 0, string comment = null, params BooksGenres[] genres)
            : base(name, price,productID, quantity, comment)
        {
            this.Author = author;
            this.NumberOfPages = numberOfPages;
            this.Genres = new List<BooksGenres>(genres.Length);
            foreach (BooksGenres genre in genres)
            {
                this.genres.Add(genre);
            }
        }

        public static Book CreateBook()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter author:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter number of pages:");
            int numOfPages = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter comment.");
            string comment = Console.ReadLine();
            Console.WriteLine("Choose genre:");
            int genreInt = int.Parse(Console.ReadLine());
            return new Book(name, price, author, numOfPages, id, quantity, comment, (BooksGenres)genreInt);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("ID:" + this.ProductID);
            result.AppendLine("Type:" + this.GetType().Name);
            result.AppendLine("Name:" + this.Name);
            result.AppendLine("Price:" + this.Price);
            result.AppendLine("Quantity:" + this.Quantity);
            result.AppendLine("Author:" + this.Author);
            result.AppendLine("Number Of Pages:" + this.NumberOfPages);
			result.Append("Genres: ");
            foreach (BooksGenres genre in this.genres)
            {
                result.Append(genre + " ");
            }

            return result.ToString();
        }
    }
}