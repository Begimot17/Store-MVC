using OnlineStore.Mappers;
using OnlineStore.Models;
using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Repository;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class UserController:Controller
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public ActionResult Index(string searchQuery)
        {
            var options = new UserFilterOptions { SearchQuery = searchQuery };
            var users = _userRepository.GetUsers(options)?.ToViewModel() ?? new List<UserViewModel>();

            return View(new UsersViewModel { Users = users });
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _userRepository.Delete(id);

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
            _userRepository.Create(model.ToDto());

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            _userRepository.Update(model.ToDto());

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var user = _userRepository.GetUser(id)?.ToViewModel();

            return View(user);
        }
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var user = _userRepository.GetUser(id)?.ToViewModel();

            return View(user);
        }
        
    }
}

