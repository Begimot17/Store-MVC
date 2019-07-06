using Store.Dal.CodeFirst.Entities;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product model)
        {
            return new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,
                Manufacturer = model.Manufacturer.ToDto(),
                Price = model.Price,
                Currency = model.Currency,
                Category = model.Category.ToDto()
            };
        }

        public static Product ToEntity(this ProductDto model)
        {
            return new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,
                Manufacturer = model.Manufacturer.ToEntity(),
                Price = model.Price,
                Currency = model.Currency,
                Category = model.Category.ToEntity()
            };
        }
    }
}
