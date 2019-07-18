using OnlineStore.BLL.Dtos.User;
using OnlineStore.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts.User
{
    public interface IUserService
    {
        void Create(UserBllDto model);
        void Update(UserBllDto model);
        void Delete(Guid id);
        UserBllDto GetUser(Guid id);
        UserBllDto GetUser(string UserName);

        IEnumerable<UserBllDto> GetUsers(UserFilterOption options);
    }
}
