using OnlineStore.BLL.Contracts.Item;
using OnlineStore.BLL.Contracts.Order;
using OnlineStore.BLL.Contracts.Product;
using OnlineStore.BLL.Contracts.User;
using OnlineStore.Mappers;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public enum Status
    {
        Cart,
        Purchase,
        Requested,
        Approved,
        Realeased,
        Dismissed
    }
    [Authorize]
    public class CartController : Controller
    {
        private IItemService _itemService;
        private IOrderService _orderService;
        private IProductService _productService;
        private IUserService _userService;


        public CartController(IItemService itemService, IOrderService orderService, IProductService productService, IUserService userService)
        {
            _itemService = itemService;
            _orderService = orderService;
            _productService = productService;
            _userService = userService;

        }
        [HttpGet]
        public ActionResult Buy(Guid Id)
        {
            var items = _itemService.GetItem(Id);
            if (User.IsInRole("Users") && items.Status == "Cart")
            {
                items.Status = Status.Purchase.ToString();

            }
            else if (User.IsInRole("Manager"))
            {
                items.Status = Status.Approved.ToString();
            }
            _itemService.Update(items);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Index()
        {
            var items = _itemService.GetItems().ToViewModel() ?? new List<ItemViewModel>();
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

            var items = _itemService.GetItems().Count();
            ItemViewModel item = new ItemViewModel();
            item.Product = _productService.GetProduct(Id).ToViewModel();
            item.Order = new OrderViewModel
            {
                User = _userService.GetUser(User.Identity.Name).ToViewModel()
                ,
                Number = $"NZ-{items + 1}"
            };
            item.Quantity = Qty;
            item.AllPrice = Qty * item.Product.Price;
            item.Status = Status.Cart.ToString();
            _itemService.Create(item.ToDto());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var items = _itemService.GetItem(id);

            if (User.IsInRole("Manager"))
            {
                items.Status = Status.Dismissed.ToString();
            }
            else if (User.IsInRole("Users") && (items.Status == "Cart" || items.Status == "Purchase"))
            {
                items.Status = Status.Realeased.ToString();
            }
            _itemService.Update(items);
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
            var user = _itemService.GetItem(id)?.ToViewModel();

            return View(user);
        }
    }
}