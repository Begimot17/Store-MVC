using OnlineStore.Models;
using Store.Dtos.Data.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this OrderDto model)
        {
            return new OrderViewModel
            {
                Id = model.Id,
                Number=model.Number,
                User=model.User.ToViewModel()

            };
        }

        public static OrderDto ToDto(this OrderViewModel model)
        {
            return new OrderDto
            {
                Id = model.Id,
                Number = model.Number,
                User = model.User.ToViewModel()
            };
        }

        public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<OrderDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<OrderDto> ToViewModel(this IEnumerable<OrderViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static OrderDto ToViewModel(this OrderViewModel model)
        {
            return new OrderDto
            {
                Id = model.Id,
                Number = model.Number,
                User = model.User.ToViewModel()
            };
        }
    }
}