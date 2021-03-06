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
        private IProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            _productRepository.Create(model.ToDto());

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Index()
        {
            var products = _productRepository.GetProducts().ToViewModel() ?? new List<ProductViewModel>();
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