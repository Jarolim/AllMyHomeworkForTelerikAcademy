using System;
using System.Collections.Generic;
using System.Text;

namespace EShop
{
    public class Game : Product
    {
        private string year;
        private string developer;
        private List<GameGenre> gameGenre;

        public List<GameGenre> GameGenre
        {
            get { return this.gameGenre; }
            set { this.gameGenre = value; }
        }

        public string Year
        {
            get { return this.year; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter game's market launch year.");
                }
                this.year = value;
            }
        }

        public string Developer
        {
            get { return this.developer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter game's developer.");
                }
                this.developer = value;
            }
        }

        public Game(string name, decimal price, int productID, int quantity, string comment, string developer, string year, params GameGenre[] genre)
            : base(name, price, productID, quantity, comment)
        {
            this.Developer = developer;
            this.Year = year;
            this.GameGenre = new List<GameGenre>(genre.Length);
            foreach (GameGenre gGenre in genre)
            {
                this.gameGenre.Add(gGenre);
            }
        }

        public static Game CreateGame()
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
            Console.WriteLine("Enter developer:");
            string dev = Console.ReadLine();
            Console.WriteLine("Enter year:");
            string year = Console.ReadLine();
            Console.WriteLine("Enter genre index:");
            int genreInt = int.Parse(Console.ReadLine());
            return new Game(name, price, id, quantity, comment, dev, year, (GameGenre)genreInt);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("ID:" + this.ProductID);
            result.AppendLine("Type:" + this.GetType().Name);
            result.AppendLine("Name:" + this.Name);
            result.AppendLine("Price:" + this.Price);
            result.AppendLine("Quantity:" + this.Quantity);
            result.AppendLine("Developer:" + this.Developer);
            result.AppendLine("Year:" + this.Year);
            result.Append("Genres: ");
            foreach (GameGenre genre in this.gameGenre)
            {
                result.Append(genre + " ");
            }

            return result.ToString();
        }
    }
}