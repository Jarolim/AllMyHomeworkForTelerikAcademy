using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCollectionsWithSqlite
{
    internal class Program
    {
        private static readonly SQLiteConnectionWrapper db = new SQLiteConnectionWrapper(MainSettings.Default.DbConnectionString);

        private static void Main(string[] args)
        {
            ReadBooksInfo();
            SearchForBook("Hello world");
            AddBook("Pink panter", new DateTime(2001, 3, 10), 445633556, "Melany Flitter");
        }

        private static void AddBook(string bookName, DateTime datePublish, long isbn, string author)
        {
            db.Open();
            using (db)
            {
                string bookStr = "INSERT INTO books " +
              "(titleBook, publishDate, ISBN) VALUES " +
              "(@title, @date, @isbn)";
                SQLiteCommand addBook = new SQLiteCommand(bookStr, db.ConnectionHandle);
                addBook.Parameters.AddWithValue("@title", bookName);
                addBook.Parameters.AddWithValue("@date", datePublish);
                addBook.Parameters.AddWithValue("@isbn", isbn);
                addBook.ExecuteNonQuery();

                SQLiteCommand cmdSelectIdentity = new SQLiteCommand("SELECT last_insert_rowid()", db.ConnectionHandle);
                long insertedRecordId = (long)cmdSelectIdentity.ExecuteScalar();

                string authorStr = "INSERT INTO authors " +
                            "(Books_idBooks, AuthorName) VALUES " +
                            "(@bookId, @name)";
                SQLiteCommand addAuthor = new SQLiteCommand(authorStr, db.ConnectionHandle);
                addAuthor.Parameters.AddWithValue("@bookId", (int)insertedRecordId);
                addAuthor.Parameters.AddWithValue("@name", author);
                addAuthor.ExecuteNonQuery();
            }
        }

        private static void SearchForBook(string input)
        {
            db.Open();
            using (db)
            {

                string sqlStr = "SELECT AuthorName, titleBook, publishDate, ISBN FROM books " +
                    "JOIN authors " +
                    "ON authors.Books_idBooks = books.idBooks " +
                    "WHERE titleBook LIKE @input";
                SQLiteParameter cmdParam = new SQLiteParameter("@input", "%" + input + "%");
                SQLiteCommand cmd = new SQLiteCommand(sqlStr, db.ConnectionHandle);
                cmd.Parameters.Add(cmdParam);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string author = (string)reader["AuthorName"];
                        string title = (string)reader["titleBook"];
                        DateTime date = (DateTime)reader["publishDate"];
                        long isbn = (long)reader["ISBN"];
                        Console.WriteLine("{0}: {1} {2} {3}", author, title, date, isbn);
                    }
                }
            }
        }

        private static void ReadBooksInfo()
        {
            db.Open();
            using (db)
            {

                string sqlStr = "SELECT AuthorName, titleBook, publishDate, ISBN FROM books " +
                    "JOIN authors " +
                    "ON authors.Books_idBooks = books.idBooks";
                SQLiteCommand cmd = new SQLiteCommand(sqlStr, db.ConnectionHandle);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string author = (string)reader["AuthorName"];
                        string title = (string)reader["titleBook"];

                        DateTime date = (DateTime)reader["publishDate"];
                        long isbn = (long)reader["ISBN"];
                        Console.WriteLine("{0}: {1} {2} {3}", author, title, date, isbn);
                    }
                }
            }
        }
    }
}
