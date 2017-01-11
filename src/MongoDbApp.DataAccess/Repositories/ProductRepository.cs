using MongoDB.Driver;
using MongoDbApp.DataAccess.Abstractions;
using MongoDbApp.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbApp.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(string endpointName, string databaseName, string collectionName) : base(endpointName, databaseName, collectionName)
        {
        }

        public async Task<List<Product>> GetByCategoryIdAsync(string categoryId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.CategoryId, categoryId);

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<DeleteResult> DeleteByCategoryIdAsync(string categoryId)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.CategoryId, categoryId);

            return await _collection.DeleteManyAsync(filter);
        }
    }
}
