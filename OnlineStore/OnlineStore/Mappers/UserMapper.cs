using OnlineStore.Models;
using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Repository;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToViewModel(this UserDto model)
        {
            return new UserViewModel
            {
                Id = model.Id,
                Name = model.Login,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static UserDto ToDto(this UserViewModel model)
        {
            return new UserDto
            {
                Id = model.Id,
                Login = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static IEnumerable<UserViewModel> ToViewModel(this IEnumerable<UserDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<UserDto> ToViewModel(this IEnumerable<UserViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static UserDto ToViewModel(this UserViewModel model)
        {
            return new UserDto
            {
                Id = model.Id,
                Login = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}