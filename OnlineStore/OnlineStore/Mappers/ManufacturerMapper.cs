using OnlineStore.BLL.Dtos.Manufacturer;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class ManufacturerMapper
    {
        public static ManufacturerViewModel ToViewModel(this ManufacturerBllDto model)
        {
            return new ManufacturerViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }

        public static ManufacturerBllDto ToDto(this ManufacturerViewModel model)
        {
            return new ManufacturerBllDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }

        public static IEnumerable<ManufacturerViewModel> ToViewModel(this IEnumerable<ManufacturerBllDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<ManufacturerBllDto> ToDto(this IEnumerable<ManufacturerViewModel> models)
        {
            return models.Select(x => x.ToDto());
        }

        public static ManufacturerBllDto ToViewModel(this ManufacturerViewModel model)
        {
            return new ManufacturerBllDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }
    }
}