using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Entities;
using Store.Dal.CodeFirst.Mappers;
using Store.Dtos.Data.Order;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public void Create(OrderDto model)
        {
            var entity = model.ToEntity();

            WithContext(context =>
            {
                context.Orders.Add(entity);
                context.SaveChanges();
            });
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrderDto GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var result = new OrderDto[] { };

            WithContext(context =>
            {
                result = context.Orders
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Number=x.Number,
                    User=new UserDto {
                        Id=x.User.Id,
                        Email=x.User.Email,
                        Login=x.User.Login,
                        Password=x.User.Password
                    }
                    
                }).ToArray();
            });
            return result;

        }

        public void Update(OrderDto model)
        {
            throw new NotImplementedException();
        }
    }
}
