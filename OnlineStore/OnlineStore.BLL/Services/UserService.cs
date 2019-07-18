using OnlineStore.BLL.Contracts.User;
using OnlineStore.BLL.Dtos.User;
using OnlineStore.Common.User;
using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        internal UserDto ToData(UserBllDto model)
        {
            return new UserDto
            {
                Email = model.Email,
                Id = model.Id,
                Login=model.Login,
                Password=model.Password
            };
        }
        internal UserBllDto ToBusiness(UserDto model)
        {
            return new UserBllDto
            {
                Email = model.Email,
                Id = model.Id,
                Login = model.Login,
                Password = model.Password
            };
        }
        public void Create(UserBllDto user)
        {
            _userRepository.Create(ToData(user));
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }
        public void Update(UserBllDto model)
        {
            _userRepository.Update(ToData(model));
        }

        public UserBllDto GetUser(Guid id)
        {
            return ToBusiness(_userRepository.GetUser(id));
        }

        public UserBllDto GetUser(string UserName)
        {
            return ToBusiness(_userRepository.GetUser(UserName));

        }
        private UserFilterOption ToBll(UserFilterOptions model)
        {
            return new UserFilterOption
            {
                CanDrink=model.CanDrink,
                SearchQuery=model.SearchQuery,
                PageSize=model.PageSize,
                PageNumber=model.PageNumber
            };
        }
        private UserFilterOptions ToData(UserFilterOption model)
        {
            return new UserFilterOptions
            {
                CanDrink = model.CanDrink,
                SearchQuery = model.SearchQuery,
                PageSize = model.PageSize,
                PageNumber = model.PageNumber
            };
        }
        public IEnumerable<UserBllDto> GetUsers(UserFilterOption options) =>
            _userRepository.GetUsers(ToData(options)).Select(ToBusiness);
    }
}
