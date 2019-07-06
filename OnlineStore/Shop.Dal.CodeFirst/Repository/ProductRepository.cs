using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Mappers;
using Store.Dtos.Data.Category;
using Store.Dtos.Data.Manufacturer;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class ProductRepository:BaseRepository , IProductRepository
    {
        public void Create(ProductDto model)
        {
            var entity = model.ToEntity();

            WithContext(context =>
            {
                context.Products.Add(entity);
                context.SaveChanges();
            });
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetProduct(Guid id)
        {
            ProductDto user = null;
            WithContext(context =>
            {
                user = context.Products.Single(x => x.Id.Equals(id)).ToDto();
            });

            return user;
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            var result = new ProductDto[] { };

            WithContext(context =>
            {
                result = context.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Logo = x.Logo,
                    Price = x.Price,
                    Currency = x.Currency,
                    Manufacturer = new ManufacturerDto
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name,
                        Logo = x.Manufacturer.Logo
                    },
                    Category = new CategoryDto
                    {
                        Id = x.Manufacturer.Id,
                        Name = x.Manufacturer.Name,
                    },
                }).ToArray();
            });

            return result;
        }

        public void Update(ProductDto model)
        {
            throw new NotImplementedException();
        }
    }
}
