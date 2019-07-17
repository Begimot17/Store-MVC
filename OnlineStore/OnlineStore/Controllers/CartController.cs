using OnlineStore.Mappers;
using OnlineStore.Models;
using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Entities;
using Store.Dal.CodeFirst.Repository;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [Authorize]
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
        public ActionResult Buy(Guid Id)
        {
            var items = _itemRepository.GetItem(Id);
            if (User.IsInRole("Users"))
            {
                items.Status = StatusEnum.Purchase.ToString();

            }
            else if (User.IsInRole("Manager"))
            {
                items.Status = StatusEnum.Approved.ToString();
            }
            _itemRepository.Update(items);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Index()
        {
            var items = _itemRepository.GetItems().ToViewModel() ?? new List<ItemViewModel>();
            if (User.IsInRole("Users"))
            {
                items = items.Where(x => x.Order.User.Name == User.Identity.Name);

            }
            else if (User.IsInRole("Manager"))
            {
                items = items.Where(x => x.Status == "Purchase");
            }
            else
            {
                return View(items);
            }

            return View(items);
        }
        [HttpGet]
        public ActionResult AddToCart(Guid Id, int Qty)
        {

            var items = _itemRepository.GetItems().Count();
            ItemViewModel item = new ItemViewModel();
            item.Product = _productRepository.GetProduct(Id).ToViewModel();
            item.Order = new OrderViewModel
            {
                User = _userRepository.GetUser(User.Identity.Name).ToViewModel()
                ,
                Number = $"NZ-{items + 1}"
            };
            item.Quantity = Qty;
            item.AllPrice = Qty * item.Product.Price;
            item.Status = StatusEnum.Cart.ToString();
            _itemRepository.Create(item.ToDto());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var items = _itemRepository.GetItem(id);

            if (User.IsInRole("Manager"))
            {
                items.Status = StatusEnum.Dismissed.ToString();
            }
            else if (User.IsInRole("Users"))
            {
                items.Status = StatusEnum.Realeased.ToString();
            }
            _itemRepository.Update(items);
            //_itemRepository.Delete(id);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Edit(UserViewModel model)
        //{
        //    _itemRepository.Update(model.ToDto());

        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public ActionResult Edit(Guid id)
        //{
        //    var user = _itemRepository.GetItem(id)?.ToViewModel();

        //    return View(user);
        //}
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var user = _itemRepository.GetItem(id)?.ToViewModel();

            return View(user);
        }
    }
}