using OnlineStore.Mappers;
using OnlineStore.Models;
using Store.Dal.CodeFirst;
using Store.Dal.CodeFirst.Entities;
using Store.Dal.CodeFirst.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (StoreContext sc = new StoreContext())
                {
                    user = sc.Users.FirstOrDefault(u => (u.Email == model.Email || u.Login == model.Login)
                    && u.Password == model.Password);
                }

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Such user already exists");
                }
            }
            return View(model);

        }


        // GET: Account
        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (StoreContext sc = new StoreContext())
                {
                    user = sc.Users.FirstOrDefault(u => u.Email == model.Email || u.Login == model.Login);
                }
                if (user == null)
                {
                    using (StoreContext sc = new StoreContext())
                    {
                        sc.Users.Add(new User { Email = model.Email, Password = model.Password, Login = model.Login });
                        sc.SaveChanges();
                        user = sc.Users.Where(u => u.Email == model.Email && u.Password ==
                        model.Password && u.Login == model.Login).FirstOrDefault();
                    }

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Such user already exists");
                }
            }
            return View(model);

        }
    }
}