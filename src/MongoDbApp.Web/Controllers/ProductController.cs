using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDbApp.Web.Mappers;
using MongoDbApp.DataAccess.Abstractions;
using MongoDbApp.Web.Models.Product;

namespace MongoDbApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private IProductMapper _productMapper;

        private ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, IProductMapper productMapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;

            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> List()
        {
            var items = await _productRepository.GetAllAsync();
            var viewItems = _productMapper.ToViewModel(items);

            return View(viewItems);
        }

        public async Task<IActionResult> Details(string id)
        {
            var item = await _productRepository.GetByIdAsync(id);
            var viewItem = _productMapper.ToViewModel(item);

            return View(viewItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductNewModel item)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateAsync(_productMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            var item = await _productRepository.GetByIdAsync(id);
            var itemView = _productMapper.ToEditModel(item);

            return View(itemView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditModel item)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.ReplaceAsync(_productMapper.ToDataModel(item));

                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        public async Task<IActionResult> Remove(string id)
        {
            await _productRepository.DeleteAsync(id);

            return RedirectToAction("List");
        }
    }
}
