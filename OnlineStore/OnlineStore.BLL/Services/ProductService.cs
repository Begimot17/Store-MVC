using OnlineStore.BLL.Contracts.Product;
using OnlineStore.BLL.Dtos.Category;
using OnlineStore.BLL.Dtos.Manufacturer;
using OnlineStore.BLL.Dtos.Product;
using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        internal ProductDto ToData(ProductBllDto model)
        {
            return new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,
                Manufacturer = new Store.Dtos.Data.Manufacturer.ManufacturerDto {
                    Id = model.Id,
                    Name = model.Name,
                    Logo = model.Logo
                },
                Price = model.Price,
                Currency = model.Currency,
                Category = new Store.Dtos.Data.Category.CategoryDto
                {
                    Id = model.Id,
                    Name = model.Name
                },
            };
        }
        internal ProductBllDto ToBusiness(ProductDto model)
        {
            return new ProductBllDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo,
                Manufacturer = new ManufacturerBllDto
                {
                    Id = model.Id,
                    Name = model.Name,
                    Logo = model.Logo
                },
                Price = model.Price,
                Currency = model.Currency,
                Category = new CategoryBllDto
                {
                    Id = model.Id,
                    Name = model.Name
                }
            };
        }
        public void Create(ProductBllDto model)
        {
            _productRepository.Create(ToData(model));
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }

        public ProductBllDto GetProduct(Guid id)
        {
            return ToBusiness(_productRepository.GetProduct(id));
        }

        public IEnumerable<ProductBllDto> GetProducts() =>
            _productRepository.GetProducts().Select(ToBusiness);

        public void Update(ProductBllDto model)
        {
            _productRepository.Update(ToData(model));
        }

        
    }
}
