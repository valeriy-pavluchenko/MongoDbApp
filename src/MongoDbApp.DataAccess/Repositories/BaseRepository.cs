using System.Collections.Generic;
using MongoDB.Driver;
using MongoDbApp.DataAccess.Entities;
using System.Threading.Tasks;

namespace MongoDbApp.DataAccess.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;
        protected IMongoCollection<T> _collection;

        protected BaseRepository(string endpointName, string databaseName, string collectionName)
        {
            _client = new MongoClient(endpointName);
            _database = _client.GetDatabase(databaseName);
            _collection = _database.GetCollection<T>(collectionName);
        }

        public async virtual Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task CreateAsync(T item)
        {
            await _collection.InsertOneAsync(item);
        }

        public virtual async Task<ReplaceOneResult> ReplaceAsync(T item)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, item.Id);
            var update = Builders<T>.Update.Set(x => x, item);

            return await _collection.ReplaceOneAsync(filter, item);
        }

        public virtual async Task<DeleteResult> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            return await _collection.DeleteOneAsync(filter);
        }
    }
}
