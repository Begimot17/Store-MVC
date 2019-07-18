using OnlineStore.BLL.Contracts.Order;
using OnlineStore.BLL.Dtos.Order;
using OnlineStore.BLL.Dtos.User;
using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        internal OrderDto ToData(OrderBllDto model)
        {
            return new OrderDto
            {
                Id = model.Id,
                User = new Store.Dtos.Data.User.UserDto
                {
                    Login = model.User.Login,
                    Password=model.User.Password,
                    Email=model.User.Email
                },
                Number = model.Number
            };
        }
        internal OrderBllDto ToBusiness(OrderDto model)
        {
            return new OrderBllDto
            {
                Id = model.Id,
                User = new UserBllDto
                {
                    Login = model.User.Login,
                    Password = model.User.Password,
                    Email = model.User.Email
                },
                Number = model.Number
            };
        }
        public void Create(OrderBllDto model)
        {
            _orderRepository.Create(ToData(model));

        }

        public void Delete(Guid id)
        {
            _orderRepository.Delete(id);

        }

        public OrderBllDto GetOrder(Guid id)
        {
            return ToBusiness(_orderRepository.GetOrder(id));
        }

        public IEnumerable<OrderBllDto> GetOrders() =>
            _orderRepository.GetOrders().Select(ToBusiness);

        public void Update(OrderBllDto model)
        {
            _orderRepository.Update(ToData(model));
        }
    }
}
