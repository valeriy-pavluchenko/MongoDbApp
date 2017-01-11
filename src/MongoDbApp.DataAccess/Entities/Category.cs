using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbApp.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        [BsonElement("ProductName")]
        public string Name { get; set; }
    }
}
