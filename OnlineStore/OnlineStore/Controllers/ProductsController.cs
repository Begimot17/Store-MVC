using Store.Dal.CodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Store.Dal.CodeFirst.Contracts;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Mappers;
using OnlineStore.Models;

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
            ViewBag.Manufacturers = manufacturers;
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model/*, Guid x, Guid y*/)
        {
            //model.Manufacturer.Id = x;
            //model.Category.Id = y;
            _productRepository.Create(model.ToDto());

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddManufacture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddManufacture(ManufacturerViewModel model)
        {
            _manufacturerRepository.Create(model.ToDto());

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel model)
        {
            _categoryRepository.Create(model.ToDto());

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Index(string search=null)
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
    }
}