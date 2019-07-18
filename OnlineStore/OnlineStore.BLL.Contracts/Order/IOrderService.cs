using OnlineStore.BLL.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts.Order
{
    public interface IOrderService
    {
        void Create(OrderBllDto model);
        void Update(OrderBllDto model);
        void Delete(Guid id);
        OrderBllDto GetOrder(Guid id);
        IEnumerable<OrderBllDto> GetOrders();
    }
}
