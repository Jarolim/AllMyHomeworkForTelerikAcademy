using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCollectionsWithSqlite
{
    public class SQLiteConnectionWrapper : IDisposable
    {
        private readonly SQLiteConnection dbConnection;
        private bool isConnectionOpened = false;

        public SQLiteConnection ConnectionHandle
        {
            get
            {
                return this.dbConnection;
            }
        }

        public SQLiteConnectionWrapper(string dbConnectionString)
        {
            if (dbConnectionString == null)
            {
                throw new ArgumentNullException("dbConnectionString");
            }

            this.dbConnection = new SQLiteConnection(dbConnectionString);
        }

        public void Open()
        {
            if (isConnectionOpened)
            {
                throw new InvalidOperationException("There is unclosed connection");
            }

            dbConnection.Open();
            this.isConnectionOpened = true;
        }

        public void Close()
        {
            dbConnection.Close();
            this.isConnectionOpened = false;
        }

        public void Dispose()
        {
            dbConnection.Close();
            this.isConnectionOpened = false;
        }
    }
}
