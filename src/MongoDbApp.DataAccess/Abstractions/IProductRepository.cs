using MongoDB.Driver;
using MongoDbApp.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbApp.DataAccess.Abstractions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<List<Product>> GetByCategoryIdAsync(string id);
        Task CreateAsync(Product item);
        Task<ReplaceOneResult> ReplaceAsync(Product item);
        Task<DeleteResult> DeleteAsync(string id);
        Task<DeleteResult> DeleteByCategoryIdAsync(string id);
    }
}
