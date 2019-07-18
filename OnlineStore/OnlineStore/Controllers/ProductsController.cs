using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Mappers;
using OnlineStore.Models;
using OnlineStore.Enum;
using OnlineStore.BLL.Contracts.Category;
using OnlineStore.BLL.Contracts.Manufacturer;
using OnlineStore.BLL.Contracts.Product;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private ICategoryService _categoryService;

        private IManufacturerService _manufacturerService;

        private IProductService _productService;
        public ProductsController(ICategoryService CategoryService, 
            IManufacturerService ManufacturerService, IProductService ProductService)
        {
            _categoryService =  CategoryService;
            _productService =  ProductService;
            _manufacturerService =  ManufacturerService;
        }
        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.GetCategory().ToViewModel() ?? new List<CategoryViewModel>();
            var manufacturers = _manufacturerService.GetManufacturer().ToViewModel() ?? new List<ManufacturerViewModel>();
            var currency = System.Enum.GetValues(typeof(Сurrency));
            ViewBag.Currency = new SelectList(currency);
            ViewBag.Category = new SelectList(categories, "Id", "Name"); ;
            ViewBag.Manufacturer = new SelectList(manufacturers, "Id", "Name"); ;
            return View();
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            model.Category = _categoryService.GetCategory(model.Category.Id).ToViewModel();
            model.Manufacturer = _manufacturerService.GetManufacturer(model.Manufacturer.Id).ToViewModel();
            _productService.Create(model.ToDto());
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult AddManufacture()
        {
            return View();
        }
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult AddManufacture(ManufacturerViewModel model)
        {
            _manufacturerService.Create(model.ToDto());

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [Authorize(Roles = "Administrators")]
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _productService.Delete(id);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel model)
        {
            _categoryService.Create(model.ToDto());

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public ActionResult Index(Guid? CategoryId,string search = null)
        {
            var products = _productService.GetProducts().ToViewModel() ?? new List<ProductViewModel>();
            var categories = _categoryService.GetCategory().ToViewModel() ?? new List<CategoryViewModel>();
            if (CategoryId != null)
            {
               products = products.Where(x => x.Category.Id==CategoryId);
            }
            if (search != null)
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }
            ViewBag.Category = new SelectList(categories, "Id", "Name");
            var model = new ProductsViewModel { Products = products };
            return View(model);
        }


        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var product = _productService.GetProduct(id)?.ToViewModel();
            return View(product);
        }
        [Authorize(Roles = "Administrators")]

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            model.Category = _categoryService.GetCategory(model.Category.Id).ToViewModel();
            model.Manufacturer = _manufacturerService.GetManufacturer(model.Manufacturer.Id).ToViewModel();
            _productService.Update(model.ToDto());
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrators")]

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var categories = _categoryService.GetCategory().ToViewModel() ?? new List<CategoryViewModel>();
            var manufacturers = _manufacturerService.GetManufacturer().ToViewModel() ?? new List<ManufacturerViewModel>();
            var currency = System.Enum.GetValues(typeof(Сurrency));
            ViewBag.Currency = new SelectList(currency);
            ViewBag.Category = new SelectList(categories, "Id", "Name"); ;
            ViewBag.Manufacturer = new SelectList(manufacturers, "Id", "Name"); ;
            var product = _productService.GetProduct(id)?.ToViewModel();

            return View(product);
        }
    }
}