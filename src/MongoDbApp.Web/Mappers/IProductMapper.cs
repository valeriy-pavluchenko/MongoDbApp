using MongoDbApp.DataAccess.Entities;
using MongoDbApp.Web.Models.Product;
using System.Collections.Generic;

namespace MongoDbApp.Web.Mappers
{
    public interface IProductMapper
    {
        ProductViewModel ToViewModel(Product item);
        List<ProductViewModel> ToViewModel(List<Product> items);
        ProductEditModel ToEditModel(Product item);
        List<ProductEditModel> ToEditModel(List<Product> items);
        Product ToDataModel(ProductEditModel item);
        List<Product> ToDataModel(List<ProductEditModel> items);
        Product ToDataModel(ProductNewModel item);
        List<Product> ToDataModel(List<ProductNewModel> items);
    }
}
