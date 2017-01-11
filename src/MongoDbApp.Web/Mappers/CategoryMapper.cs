using MongoDbApp.DataAccess.Entities;
using MongoDbApp.Web.Models.Category;
using System.Collections.Generic;

namespace MongoDbApp.Web.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public CategoryViewModel ToViewModel(Category item)
        {
            return new CategoryViewModel
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public List<CategoryViewModel> ToViewModel(List<Category> items)
        {
            var list = new List<CategoryViewModel>();

            foreach (var item in items)
            {
                list.Add(ToViewModel(item));
            }

            return list;
        }

        public CategoryEditModel ToEditModel(Category item)
        {
            return new CategoryEditModel
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public List<CategoryEditModel> ToEditModel(List<Category> items)
        {
            var list = new List<CategoryEditModel>();

            foreach (var item in items)
            {
                list.Add(ToEditModel(item));
            }

            return list;
        }

        public Category ToDataModel(CategoryEditModel item)
        {
            return new Category
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public List<Category> ToDataModel(List<CategoryEditModel> items)
        {
            var list = new List<Category>();

            foreach (var item in items)
            {
                list.Add(ToDataModel(item));
            }

            return list;
        }

        public Category ToDataModel(CategoryNewModel item)
        {
            return new Category
            {
                Name = item.Name,
            };
        }

        public List<Category> ToDataModel(List<CategoryNewModel> items)
        {
            var list = new List<Category>();

            foreach (var item in items)
            {
                list.Add(ToDataModel(item));
            }

            return list;
        }
    }
}
