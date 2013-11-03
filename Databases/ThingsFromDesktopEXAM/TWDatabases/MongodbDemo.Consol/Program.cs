using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongodbDemo.Data;
using MongodbDemo.Data.Library;

namespace MongodbDemo.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbSearch = LoadData<Book>().ToList();

        }

        private static IQueryable<T> LoadData<T>()
        {
            try
            {
                return MongoDbProvider.db.GetCollection<T>(typeof(T).Name).AsQueryable();
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }
    }
}
