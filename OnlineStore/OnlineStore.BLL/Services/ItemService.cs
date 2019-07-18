using OnlineStore.BLL.Contracts.Item;
using OnlineStore.BLL.Dtos.Category;
using OnlineStore.BLL.Dtos.Item;
using OnlineStore.BLL.Dtos.Manufacturer;
using OnlineStore.BLL.Dtos.Order;
using OnlineStore.BLL.Dtos.Product;
using OnlineStore.BLL.Dtos.User;
using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Services
{
    public class ItemService: IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        private ItemDto ToData(ItemBllDto model)
        {
            return new ItemDto
            {
                Id = model.Id,
                Order = new Store.Dtos.Data.Order.OrderDto
                {
                    Id = model.Order.Id,
                    Number = model.Order.Number,
                    User = new Store.Dtos.Data.User.UserDto
                    {
                        Id = model.Order.User.Id,
                        Login = model.Order.User.Login,
                        Email = model.Order.User.Email,
                        Password = model.Order.User.Password
                    }
                },
                Product = new Store.Dtos.Data.Product.ProductDto
                {
                    Id = model.Product.Id,
                    Name = model.Product.Name,
                    Description = model.Product.Description,
                    Logo = model.Product.Logo,
                    Manufacturer = new Store.Dtos.Data.Manufacturer.ManufacturerDto {
                        Id = model.Product.Manufacturer.Id,
                        Name = model.Product.Manufacturer.Name,
                        Logo = model.Product.Manufacturer.Logo
                    },
                    Price = model.Product.Price,
                    Currency = model.Product.Currency,
                    Category = new Store.Dtos.Data.Category.CategoryDto
                    {
                        Id = model.Product.Category.Id,
                        Name = model.Product.Category.Name,
                    }
                },
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,
                Status = model.Status
            };
        }
        private ItemBllDto ToBusiness(ItemDto model)
        {
            return new ItemBllDto
            {
                Id = model.Id,
                Order = new OrderBllDto
                {
                    Id = model.Order.Id,
                    Number = model.Order.Number,
                    User = new UserBllDto
                    {
                        Id = model.Order.User.Id,
                        Login = model.Order.User.Login,
                        Email = model.Order.User.Email,
                        Password = model.Order.User.Password
                    }
                },
                Product = new ProductBllDto
                {
                    Id = model.Product.Id,
                    Name = model.Product.Name,
                    Description = model.Product.Description,
                    Logo = model.Product.Logo,
                    Manufacturer = new ManufacturerBllDto
                    {
                        Id = model.Product.Manufacturer.Id,
                        Name = model.Product.Manufacturer.Name,
                        Logo = model.Product.Manufacturer.Logo
                    },
                    Price = model.Product.Price,
                    Currency = model.Product.Currency,
                    Category = new CategoryBllDto
                    {
                        Id = model.Product.Category.Id,
                        Name = model.Product.Category.Name,
                    }
                },
                Quantity = model.Quantity,
                AllPrice = model.AllPrice,
                Status = model.Status
            };
        }
        public void Create(ItemBllDto model)
        {
            _itemRepository.Create(ToData(model));

        }

        public void Delete(Guid id)
        {
            _itemRepository.Delete(id);

        }

        public ItemBllDto GetItem(Guid id)
        {
            return ToBusiness(_itemRepository.GetItem(id));
        }

        public IEnumerable<ItemBllDto> GetItems() =>
            _itemRepository.GetItems().Select(ToBusiness);

        public void Update(ItemBllDto model)
        {
            _itemRepository.Update(ToData(model));

        }
    }
}
