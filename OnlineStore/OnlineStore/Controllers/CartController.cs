using OnlineStore.Domain.Entities;
using OnlineStore.Mappers;
using OnlineStore.Models;
using OnlineStore.WebUI.Models;
using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Repository;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private IItemRepository _itemRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;


        public CartController()
        {
            _itemRepository = new ItemRepository();
            _orderRepository = new OrderRepository();
            _productRepository = new ProductRepository();
            _userRepository = new UserRepository();



        }
        [HttpGet]
        public ActionResult Index()
        {
            var items = _itemRepository.GetItems().ToViewModel() ?? new List<ItemViewModel>();
            
            return View(items);
        }
        [HttpGet]
        public ActionResult AddToCart(Guid ProductId,int quantity=3)
        {
            var userView = _userRepository.GetUsers(null).ToViewModel();
            ItemViewModel item = new ItemViewModel();
            item.Product = _productRepository.GetProduct(ProductId).ToViewModel();
            item.Order = new OrderViewModel
            {
                
                User = new UserViewModel
                {
                   Id=userView.Last().Id,
                   Name= userView.Last().Name,
                    Password = userView.Last().Password,
                    Email= userView.Last().Email
                }
                ,
                Number = "Number random"
            };
            item.Quantity = quantity;
            item.Status = "Cart";
            _itemRepository.Create(item.ToDto());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _itemRepository.Delete(id);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Edit(UserViewModel model)
        //{
        //    _itemRepository.Update(model.ToDto());

        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var user = _itemRepository.GetItem(id)?.ToViewModel();

            return View(user);
        }
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var user = _itemRepository.GetItem(id)?.ToViewModel();

            return View(user);
        }
    }
}