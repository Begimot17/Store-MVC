using Store.Dtos.Data.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface IOrderRepository
    {
        void Create(OrderDto model);
        void Update(OrderDto model);
        void Delete(Guid id);
        OrderDto GetOrder(Guid id);
        IEnumerable<OrderDto> GetOrders();
    }
}
