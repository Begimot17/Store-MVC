using OnlineStore.Models;
using Store.Dtos.Data.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class ManufacturerMapper
    {
        public static ManufacturerViewModel ToViewModel(this ManufacturerDto model)
        {
            return new ManufacturerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }

        public static ManufacturerDto ToDto(this ManufacturerViewModel model)
        {
            return new ManufacturerDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }

        public static IEnumerable<ManufacturerViewModel> ToViewModel(this IEnumerable<ManufacturerDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<ManufacturerDto> ToDto(this IEnumerable<ManufacturerViewModel> models)
        {
            return models.Select(x => x.ToDto());
        }

        public static ManufacturerDto ToViewModel(this ManufacturerViewModel model)
        {
            return new ManufacturerDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }
    }
}