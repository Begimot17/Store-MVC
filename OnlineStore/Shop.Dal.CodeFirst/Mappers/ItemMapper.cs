using Store.Dal.CodeFirst.Entities;
using Store.Dtos.Data.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Mappers
{
    public static class ItemMapper
    {
        public static ItemDto ToDto(this Item model)
        {
            return new ItemDto
            {
                Id = model.Id,
                Product = model.Product.ToDto(),
                Order = model.Order.ToDto(),
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,

                Status = model.Status
            };
        }

        public static Item ToEntity(this ItemDto model)
        {
            return new Item
            {
                Id = model.Id,
                ProductId = model.Product.Id,
                Order= new Order
                {
                    Id=model.Order.Id,
                    UserId= model.Order.User.Id,
                    Number = model.Order.Number
                },
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,

                Status = model.Status
            };
        }
    }
}
