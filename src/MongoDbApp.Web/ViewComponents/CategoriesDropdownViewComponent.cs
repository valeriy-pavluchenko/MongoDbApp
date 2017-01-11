using Microsoft.AspNetCore.Mvc;
using MongoDbApp.DataAccess.Abstractions;
using MongoDbApp.Web.Mappers;
using System.Threading.Tasks;

namespace MongoDbApp.Web.ViewComponents
{
    public class CategoriesDropdownViewComponent : ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        private ICategoryMapper _categoryMapper;

        public CategoriesDropdownViewComponent(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper)
        {
            _categoryRepository = categoryRepository;
            _categoryMapper = categoryMapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(string bindingProperty, string id = null)
        {
            ViewBag.BindingProperty = bindingProperty;
            ViewBag.Id = id;

            var items = await _categoryRepository.GetAllAsync();
            var itemsView = _categoryMapper.ToViewModel(items);

            return View(itemsView);
        }
    }
}
