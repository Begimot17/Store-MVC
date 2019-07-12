using Store.Dal.CodeFirst.Entities;
using Store.Dtos.Data.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(this Order model)
        {
            return new OrderDto
            {
                Id = model.Id,
                User = model.User.ToDto(),
                Number = model.Number
            };
        }

        public static Order ToEntity(this OrderDto model)
        {
            return new Order
            {
                Id = model.Id,
                User = model.User.ToEntity(),
                Number = model.Number
            };
        }
    }
}
