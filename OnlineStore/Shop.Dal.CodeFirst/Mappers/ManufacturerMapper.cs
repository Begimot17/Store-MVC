using Store.Dal.CodeFirst.Entities;
using Store.Dtos.Data.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Mappers
{
    public static class ManufacturerMapper
    {
        public static ManufacturerDto ToDto(this Manufacturer model)
        {
            return new ManufacturerDto
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }

        public static Manufacturer ToEntity(this ManufacturerDto model)
        {
            return new Manufacturer
            {
                Id = model.Id,
                Name = model.Name,
                Logo = model.Logo
            };
        }
    }
}
