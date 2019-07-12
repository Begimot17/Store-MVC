using Store.Dal.CodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Store.Dal.CodeFirst.Contracts;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Mappers;
using OnlineStore.Models;
using OnlineStore.Enum;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private ICategoryRepository _categoryRepository;

        private IManufacturerRepository _manufacturerRepository;

        private IProductRepository _productRepository;

        public ProductsController()
        {
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();
            _manufacturerRepository = new ManufacturerRepository();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryRepository.GetCategory().ToViewModel() ?? new List<CategoryViewModel>();
            var manufacturers = _manufacturerRepository.GetManufacturer().ToViewModel() ?? new List<ManufacturerViewModel>();
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
            model.Category = _categoryRepository.GetCategory(model.Category.Id).ToViewModel();
            model.Manufacturer = _manufacturerRepository.GetManufacturer(model.Manufacturer.Id).ToViewModel();
            _productRepository.Create(model.ToDto());
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
            _manufacturerRepository.Create(model.ToDto());

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
            _productRepository.Delete(id);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel model)
        {
            _categoryRepository.Create(model.ToDto());

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Index(string search = null)
        {
            var products = _productRepository.GetProducts().ToViewModel() ?? new List<ProductViewModel>();
            if (search != null)
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }
            ViewBag.Products = products;
            return View();
        }


        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var product = _productRepository.GetProduct(id)?.ToViewModel();

            return View(product);
        }
        [Authorize(Roles = "Administrators")]

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            model.Category = _categoryRepository.GetCategory(model.Category.Id).ToViewModel();
            model.Manufacturer = _manufacturerRepository.GetManufacturer(model.Manufacturer.Id).ToViewModel();
            _productRepository.Update(model.ToDto());
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrators")]

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var categories = _categoryRepository.GetCategory().ToViewModel() ?? new List<CategoryViewModel>();
            var manufacturers = _manufacturerRepository.GetManufacturer().ToViewModel() ?? new List<ManufacturerViewModel>();
            var currency = System.Enum.GetValues(typeof(Сurrency));
            ViewBag.Currency = new SelectList(currency);
            ViewBag.Category = new SelectList(categories, "Id", "Name"); ;
            ViewBag.Manufacturer = new SelectList(manufacturers, "Id", "Name"); ;
            var product = _productRepository.GetProduct(id)?.ToViewModel();

            return View(product);
        }
    }
}