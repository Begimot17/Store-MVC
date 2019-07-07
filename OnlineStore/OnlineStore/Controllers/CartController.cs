//using OnlineStore.Mappers;
//using OnlineStore.Models;
//using Store.Dal.CodeFirst.Contracts;
//using Store.Dal.CodeFirst.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace OnlineStore.Controllers
//{
//    public class CartController : Controller
//    {
//        private ICartRepository _cartRepository;

//        public CartController()
//        {
//            _cartRepository = new CartRepository();
//        }
//        [HttpGet]
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Create(ItemViewModel model)
//        {
//            _cartRepository.AddItem(model.ToDto());

//            return RedirectToAction("Index");
//        }
//        [HttpGet]
//        public ActionResult Index()
//        {
//            var products = _cartRepository.GetProducts().ToViewModel() ?? new List<ProductViewModel>();
//            ViewBag.Products = products;
//            return View();
//        }
//        [HttpGet]
//        public ActionResult Details(Guid id)
//        {
//            var product = _cartRepository.GetProduct(id)?.ToViewModel();

//            return View(product);
//        }
//    }
//}