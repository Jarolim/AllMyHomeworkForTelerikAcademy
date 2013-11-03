using System;
using System.Collections.Generic;
using System.Text;

namespace EShop
{
    public class Movie : Product
    {
        private string country;
        private int duration;
        private List<MovieGenre> genres;

        public List<MovieGenre> Genres
        {
            get { return this.genres; }
            private set { this.genres = value; }
        }

        public string Country
        {
            get { return this.country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter movie's origin country.");
                }
                this.country = value;
            }
        }

        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input! You should enter positive number for movie duration.");
                }
                this.duration = value;
            }
        }

		public Movie(string name, decimal price, int productID, int quantity, string comment, string country, int duration, params MovieGenre[] genres)
            : base(name, price,productID, quantity, comment)
        {
            this.Country = country;
            this.Duration = duration;
            this.Genres = new List<MovieGenre>(genres.Length);
            foreach (MovieGenre genre in genres)
            {
                this.genres.Add(genre);
            }
        }

        public static Movie CreateMovie()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter product id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter comment:");
            string comment = Console.ReadLine();
            Console.WriteLine("Enter country:");
            string country = Console.ReadLine();
            Console.WriteLine("Enter duraion:");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre index:");
            int genreInt = int.Parse(Console.ReadLine());
            return new Movie(name, price, id, quantity, comment, country, duration, (MovieGenre)genreInt);
 
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("ID: " + this.ProductID);
            result.AppendLine("Type: " + this.GetType().Name);
            result.AppendLine("Name: " + this.Name);
            result.AppendLine("Price: " + this.Price);
            result.AppendLine("Quantity: " + this.Quantity);
            result.AppendLine("Country: " + this.Country);
            result.AppendLine("Duration: " + this.Duration);
			result.Append("Genres: ");
            foreach (MovieGenre genre in this.genres)
            {
				result.Append(genre + " ");
            }

            return result.ToString();
        }
    }
}