using System;
using System.Collections.Generic;
using System.Text;

namespace EShop
{
    public class Music : Product
    {
        //Fields:
        private string artist;
        private string albumName;
        private int numberOfSongs;
        private List<MusicGenres> genres;

        //Properties:
        public List<MusicGenres> Genres
        {
            get { return this.genres; }
            private set { this.genres = value; }
        }

        public string Artist
        {
            get { return this.artist; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter music's artist.");
                }
                this.artist = value;
            }
        }

        public string AlbumName
        {
            get { return this.albumName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input! You should enter music's album name.");
                }
                this.albumName = value;
            }
        }

        public int NumberOfSongs
        {
            get { return this.numberOfSongs; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Invalid input! You should enter positive number for music's number of songs.");
                }
                this.numberOfSongs = value;
            }
        }

        //Constructors:
		public Music(string name, decimal price, string artist, string albumName, int numberOfSongs, int productID, int quantity = 0, string comment = null, params MusicGenres[] genres)
            : base(name, price,productID, quantity, comment)
        {
            this.Artist = artist;
            this.AlbumName = albumName;
            this.NumberOfSongs = numberOfSongs;
            this.Genres = new List<MusicGenres>(genres.Length);
            foreach (MusicGenres genre in genres)
            {
                this.Genres.Add(genre);
            }
        }

        public static Music CreateMusic()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter artist:");
            string artist = Console.ReadLine();
            Console.WriteLine("Enter album name:");
            string albumName = Console.ReadLine();
            Console.WriteLine("Enter number of songs:");
            int numberOfSongs = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose genre:");
            int genreInt = int.Parse(Console.ReadLine());
            return new Music(name, price, artist, albumName, numberOfSongs, id, quantity, null, (MusicGenres)genreInt);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("ID:" + this.ProductID);
            result.AppendLine("Type:" + this.GetType().Name);
            result.AppendLine("Name:" + this.Name);
            result.AppendLine("Price:" + this.Price);
            result.AppendLine("Quantity:" + this.Quantity);
            result.AppendLine("Artist:" + this.Artist);
            result.AppendLine("Album Name:" + this.AlbumName);
            result.AppendLine("Number Of Songs:" + this.NumberOfSongs);
			result.Append("Genres: ");
            foreach (MusicGenres genre in this.genres)
            {
                result.Append(genre + " ");
            }

            return result.ToString();
        }
    }

}