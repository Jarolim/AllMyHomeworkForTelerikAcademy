using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dictionary
{
    public class Word
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Value { get; set; }

        public string Translation { get; set; }

        [BsonConstructor]
        public Word(string value, string translation)
        {
            this.Value = value;
            this.Translation = translation;
        }

        public override string ToString()
        {
            string result = this.Value + Environment.NewLine + this.Translation;
            return result;
        }
    }
}