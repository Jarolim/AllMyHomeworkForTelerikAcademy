using MongoDB.Bson;

namespace MongodbDemo.Data.Library
{
    public class Book
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BsonDateTime PublishDate { get; set; }
    }
}
