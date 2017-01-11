using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbApp.DataAccess.Entities
{
    public class Product : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
        [BsonElement("IsAvailable")]
        public bool IsAvailable { get; set; }
        [BsonElement("CategoryId")]
        public string CategoryId { get; set; }
    }
}
