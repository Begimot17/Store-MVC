using OnlineStore.BLL.Contracts.User;
using OnlineStore.Common.User;
using OnlineStore.Mappers;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UserController:Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index(string searchQuery=null)
        {
            var options = new UserFilterOption { SearchQuery = searchQuery };
            var users = _userService.GetUsers(options)?.ToViewModel() ?? new List<UserViewModel>();

            return View(new UsersViewModel { Users = users });
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _userService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            _userService.Create(model.ToDto());

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            _userService.Update(model.ToDto());

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var user = _userService.GetUser(id)?.ToViewModel();

            return View(user);
        }
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var user = _userService.GetUser(id)?.ToViewModel();

            return View(user);
        }
        
    }
}

