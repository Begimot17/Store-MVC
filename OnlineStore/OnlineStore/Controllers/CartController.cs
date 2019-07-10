using OnlineStore.Domain.Entities;
using OnlineStore.Models;
using OnlineStore.WebUI.Models;
using Store.Dal.CodeFirst.Contracts;
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
        private IProductRepository repository;

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }
        public RedirectToRouteResult AddToCart(Guid Id, string returnUrl)
        {
            ProductDto product = repository.GetProducts()
                .FirstOrDefault(p => p.Id == Id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Guid Id, string returnUrl)
        {
            ProductDto product = repository.GetProducts()
                .FirstOrDefault(g => g.Id == Id);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}