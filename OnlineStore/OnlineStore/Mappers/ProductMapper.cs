using OnlineStore.Models;
using Store.Dtos.Data.Category;
using Store.Dtos.Data.Manufacturer;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(this ProductDto model)
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

        public static ProductDto ToDto(this ProductViewModel model)
        {
            return new ProductDto
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

        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<ProductDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<ProductDto> ToViewModel(this IEnumerable<ProductViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static ProductDto ToViewModel(this ProductViewModel model)
        {
            return new ProductDto
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