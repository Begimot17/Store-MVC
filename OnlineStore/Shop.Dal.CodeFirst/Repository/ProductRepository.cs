using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Entities;
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
    public class ProductRepository : BaseRepository, IProductRepository
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
            WithContext(context =>
            {
                var product = context.Products.Single(x => x.Id.Equals(id));

                context.Products.Remove(product);

                context.SaveChanges();
            });
        }

        public ProductDto GetProduct(Guid id)
        {
            ProductDto productDto = null;
            WithContext(context =>
            {
                productDto = context.Products.Single(x => x.Id.Equals(id)).ToDto();
            });

            return productDto;
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
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                    },
                }).ToArray();
            });

            return result;
        }

        public void Update(ProductDto model)
        {
            WithContext(context =>
            {
                var product = context.Products.Single(x => x.Id.Equals(model.Id));

                product.Id = model.Id;
                product.Name = model.Name;
                product.Logo = model.Logo;
                product.Description = model.Description;
                product.ManufacturerId = model.Manufacturer.Id;
                product.CategoryId = model.Category.Id;
                product.Price = model.Price;
                product.Currency = model.Currency;


                context.SaveChanges();
            });
        }
    }
}
