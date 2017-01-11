using MongoDB.Driver;
using MongoDbApp.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbApp.DataAccess.Abstractions
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task CreateAsync(Category item);
        Task<ReplaceOneResult> ReplaceAsync(Category item);
        Task<DeleteResult> DeleteAsync(string id);
    }
}
