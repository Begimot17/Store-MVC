using OnlineStore.BLL.Dtos.User;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToViewModel(this UserBllDto model)
        {
            return new UserViewModel
            {
                Id = model.Id,
                Name = model.Login,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static UserBllDto ToDto(this UserViewModel model)
        {
            return new UserBllDto
            {
                Id = model.Id,
                Login = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static IEnumerable<UserViewModel> ToViewModel(this IEnumerable<UserBllDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<UserBllDto> ToViewModel(this IEnumerable<UserViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static UserBllDto ToViewModel(this UserViewModel model)
        {
            return new UserBllDto
            {
                Id = model.Id,
                Login = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}