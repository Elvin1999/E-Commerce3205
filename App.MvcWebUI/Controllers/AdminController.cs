using App.Business.Abstract;
using App.Entities.Concrete;
using App.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.MvcWebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new AddProductViewModel()
            {
                Product = new Product(),
                Categories=_categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
            _productService.Add(product);
            TempData.Add("message", "Product was added successfully");
            return RedirectToAction("Index");
            }
            return View();
        }
    }
}
