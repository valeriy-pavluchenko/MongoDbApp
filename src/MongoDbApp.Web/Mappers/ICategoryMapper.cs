using MongoDbApp.DataAccess.Entities;
using MongoDbApp.Web.Models.Category;
using System.Collections.Generic;

namespace MongoDbApp.Web.Mappers
{
    public interface ICategoryMapper
    {
        CategoryViewModel ToViewModel(Category item);
        List<CategoryViewModel> ToViewModel(List<Category> items);
        CategoryEditModel ToEditModel(Category item);
        List<CategoryEditModel> ToEditModel(List<Category> items);
        Category ToDataModel(CategoryEditModel item);
        List<Category> ToDataModel(List<CategoryEditModel> items);
        Category ToDataModel(CategoryNewModel item);
        List<Category> ToDataModel(List<CategoryNewModel> items);
    }
}
