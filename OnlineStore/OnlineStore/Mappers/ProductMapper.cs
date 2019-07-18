using OnlineStore.BLL.Dtos.Product;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(this ProductBllDto model)
        {
            return new ProductViewModel
            {
               Id=model.Id,
               Name=model.Name,
               Description=model.Description,
               Logo=model.Logo,
               Price=model.Price,
               Currency=model.Currency,
                Manufacturer = model.Manufacturer.ToViewModel(),
                Category = model.Category.ToViewModel()

            };
        }

        public static ProductBllDto ToDto(this ProductViewModel model)
        {
            return new ProductBllDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,
                Price = model.Price,
                Currency = model.Currency,
                Manufacturer = model.Manufacturer.ToDto(),
                Category = model.Category.ToDto()
            };
        }

        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<ProductBllDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<ProductBllDto> ToViewModel(this IEnumerable<ProductViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static ProductBllDto ToViewModel(this ProductViewModel model)
        {
            return new ProductBllDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,
                Manufacturer = model.Manufacturer.ToViewModel(),
                Price = model.Price,
                Currency = model.Currency,
                Category = model.Category.ToViewModel()
            };
        }

    }
}