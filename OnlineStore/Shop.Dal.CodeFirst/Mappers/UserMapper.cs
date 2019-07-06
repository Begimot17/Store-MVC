using Store.Dal.CodeFirst.Entities;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Mappers
{
    public static class UserMapper
    {

        public static UserDto ToDto(this User model)
        {
            return new UserDto
            {
                Id = model.Id,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static User ToEntity(this UserDto model)
        {
            return new User
            {
                Id = model.Id,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}
