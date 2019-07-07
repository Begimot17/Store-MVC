using OnlineStore.Mappers;
using OnlineStore.Models;
using Store.Dal.CodeFirst;
using Store.Dal.CodeFirst.Entities;
using Store.Dal.CodeFirst.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static OnlineStore.Models.UserViewModel;

namespace OnlineStore.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginViewModel details, string returnUrl)
        //{
        //    return View(details);
        //}

        //[Authorize]
        //public ActionResult Logout()
        //{
        //    AuthManager.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "В доступе отказано" });
            }

            ViewBag.returnUrl = returnUrl;
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
                    user = sc.Users.FirstOrDefault(u => (u.Email == model.Email ||
                    u.Login == model.Login)
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
    }
}

