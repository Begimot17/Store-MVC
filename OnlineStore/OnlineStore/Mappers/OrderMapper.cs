using OnlineStore.BLL.Dtos.Order;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this OrderBllDto model)
        {
            return new OrderViewModel
            {
                Id = model.Id,
                Number=model.Number,
                User=model.User.ToViewModel()

            };
        }

        public static OrderBllDto ToDto(this OrderViewModel model)
        {
            return new OrderBllDto
            {
                Id = model.Id,
                Number = model.Number,
                User = model.User.ToViewModel()
            };
        }

        public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<OrderBllDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<OrderBllDto> ToViewModel(this IEnumerable<OrderViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static OrderBllDto ToViewModel(this OrderViewModel model)
        {
            return new OrderBllDto
            {
                Id = model.Id,
                Number = model.Number,
                User = model.User.ToViewModel()
            };
        }
    }
}