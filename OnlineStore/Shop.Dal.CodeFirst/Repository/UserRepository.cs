using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Mappers;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public void Create(UserDto model)
        {
            var entity = model.ToEntity();

            WithContext(context =>
            {
                context.Users.Add(entity);
                context.SaveChanges();
            });
        }

        public void Delete(Guid id)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(id));

                context.Users.Remove(user);

                context.SaveChanges();
            });
        }


        public void Update(UserDto model)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(model.Id));

                user.Id = model.Id;
                user.Login = model.Login;
                user.Email = model.Email;
                user.Password = model.Password;

                context.SaveChanges();
            });
        }
        public IEnumerable<UserDto> GetUsers(UserFilterOptions options)
        {
            var result = new UserDto[] { };

            WithContext(context =>
            {
                result = context.Users
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Login = x.Login,
                    Password = x.Password
                }).ToArray();
            });

            return result;
        }
        public UserDto GetUser(Guid id)
        {
            UserDto user = null;
            WithContext(context =>
            {
                user = context.Users.Single(x => x.Id.Equals(id)).ToDto();
            });

            return user;
        }

        public UserDto GetUser(string UserName)
        {
            UserDto user = null;
            WithContext(context =>
            {
                user = context.Users.Single(x => x.Login.Equals(UserName)).ToDto();
            });
            return user;

        }
    }
}
