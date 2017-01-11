using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDbApp.Web.Mappers;
using MongoDbApp.DataAccess.Abstractions;
using MongoDbApp.Web.Models.Category;

namespace MongoDbApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private ICategoryMapper _categoryMapper;

        private IProductRepository _productRepository;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryMapper = categoryMapper;

            _productRepository = productRepository;
        }

        public async Task<IActionResult> List()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var viewItems = _categoryMapper.ToViewModel(categories);

            return View(viewItems);
        }

        public async Task<IActionResult> Details(string id)
        {
            var item = await _categoryRepository.GetByIdAsync(id);
            var itemView = _categoryMapper.ToViewModel(item);

            return View(itemView);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryNewModel item)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateAsync(_categoryMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            var item = await _categoryRepository.GetByIdAsync(id);
            var itemView = _categoryMapper.ToEditModel(item);

            return View(itemView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditModel item)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.ReplaceAsync(_categoryMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public async Task<IActionResult> Remove(string id)
        {
            var products = await _productRepository.DeleteByCategoryIdAsync(id);
            await _categoryRepository.DeleteAsync(id);

            return RedirectToAction("List");
        }
    }
}
