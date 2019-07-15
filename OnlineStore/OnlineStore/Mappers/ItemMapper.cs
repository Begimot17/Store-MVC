using OnlineStore.Models;
using Store.Dtos.Data.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class ItemMapper
    {
        public static ItemViewModel ToViewModel(this ItemDto model)
        {
            return new ItemViewModel
            {
                Id = model.Id,
                Order = model.Order.ToViewModel(),
                Product = model.Product.ToViewModel(),
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,
                Status = model.Status


            };
        }

        public static ItemDto ToDto(this ItemViewModel model)
        {
            return new ItemDto
            {
                Id = model.Id,
                Order = model.Order.ToViewModel(),
                Product = model.Product.ToViewModel(),
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,

                Status = model.Status
            };
        }

        public static IEnumerable<ItemViewModel> ToViewModel(this IEnumerable<ItemDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<ItemDto> ToViewModel(this IEnumerable<ItemViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static ItemDto ToViewModel(this ItemViewModel model)
        {
            return new ItemDto
            {
                Id = model.Id,
                Order = model.Order.ToViewModel(),
                Product = model.Product.ToViewModel(),
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,

                Status = model.Status

            };
        }
    }
}