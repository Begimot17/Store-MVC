using OnlineStore.BLL.Dtos.Item;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class ItemMapper
    {
        public static ItemViewModel ToViewModel(this ItemBllDto model)
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

        public static ItemBllDto ToDto(this ItemViewModel model)
        {
            return new ItemBllDto
            {
                Id = model.Id,
                Order = model.Order.ToViewModel(),
                Product = model.Product.ToViewModel(),
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,

                Status = model.Status
            };
        }

        public static IEnumerable<ItemViewModel> ToViewModel(this IEnumerable<ItemBllDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<ItemBllDto> ToViewModel(this IEnumerable<ItemViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static ItemBllDto ToViewModel(this ItemViewModel model)
        {
            return new ItemBllDto
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