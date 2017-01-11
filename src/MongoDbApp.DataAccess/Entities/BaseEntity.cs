using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbApp.DataAccess.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        public string Id { get; set; }
    }
}
