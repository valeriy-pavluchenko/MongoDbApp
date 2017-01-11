using MongoDbApp.DataAccess.Abstractions;
using MongoDbApp.DataAccess.Entities;
using MongoDbApp.Web.Models.Product;
using System.Collections.Generic;

namespace MongoDbApp.Web.Mappers
{
    public class ProductMapper : IProductMapper
    {
        private ICategoryRepository _categoryRepository;

        public ProductMapper(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ProductViewModel ToViewModel(Product item)
        {
            var task = _categoryRepository.GetByIdAsync(item.CategoryId);
            task.Wait();

            return new ProductViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CategoryId = item.CategoryId,
                IsAvailable = item.IsAvailable,
                CategoryName = task.Result.Name
            };
        }

        public List<ProductViewModel> ToViewModel(List<Product> items)
        {
            var list = new List<ProductViewModel>();

            foreach (var item in items)
            {
                var product = ToViewModel(item);
                list.Add(product);
            }

            return list;
        }

        public ProductEditModel ToEditModel(Product item)
        {
            return new ProductEditModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CategoryId = item.CategoryId,
                IsAvailable = item.IsAvailable
            };
        }

        public List<ProductEditModel> ToEditModel(List<Product> items)
        {
            var list = new List<ProductEditModel>();

            foreach (var item in items)
            {
                var product = ToEditModel(item);
                list.Add(product);
            }

            return list;
        }

        public Product ToDataModel(ProductEditModel item)
        {
            return new Product
            {
                Id = item.Id,
                Name = item.Name,
                IsAvailable = item.IsAvailable,
                Price = item.Price,
                CategoryId = item.CategoryId
            };
        }

        public List<Product> ToDataModel(List<ProductEditModel> items)
        {
            var list = new List<Product>();

            foreach (var item in items)
            {
                list.Add(ToDataModel(item));
            }

            return list;
        }

        public Product ToDataModel(ProductNewModel item)
        {
            return new Product
            {
                Name = item.Name,
                IsAvailable = item.IsAvailable,
                Price = item.Price,
                CategoryId = item.CategoryId
            };
        }

        public List<Product> ToDataModel(List<ProductNewModel> items)
        {
            var list = new List<Product>();

            foreach (var item in items)
            {
                list.Add(ToDataModel(item));
            }

            return list;
        }
    }
}
