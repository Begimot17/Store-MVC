using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface IUserRepository
    {
        void Create(UserDto model);
        void Update(UserDto model);
        void Delete(Guid id);
        UserDto GetUser(Guid id);
        IEnumerable<UserDto> GetUsers(UserFilterOptions options);
    }
}
