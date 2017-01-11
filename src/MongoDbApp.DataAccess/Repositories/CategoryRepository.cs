using MongoDbApp.DataAccess.Abstractions;
using MongoDbApp.DataAccess.Entities;

namespace MongoDbApp.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(string endpointName, string databaseName, string collectionName) : base(endpointName, databaseName, collectionName)
        {
        }
    }
}
