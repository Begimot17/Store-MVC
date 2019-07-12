using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Mappers;
using Store.Dtos.Data.Category;
using Store.Dtos.Data.Item;
using Store.Dtos.Data.Manufacturer;
using Store.Dtos.Data.Order;
using Store.Dtos.Data.Product;
using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public void Create(ItemDto model)
        {
            var entity = model.ToEntity();

            WithContext(context =>
            {
                context.Items.Add(entity);
                context.SaveChanges();
            });
        }

        public void Delete(Guid id)
        {
            WithContext(context =>
            {
                var product = context.Items.Single(x => x.Id.Equals(id));

                context.Items.Remove(product);

                context.SaveChanges();
            });
        }

        public ItemDto GetItem(Guid id)
        {
            ItemDto item = null;
            WithContext(context =>
            {
                item = context.Items.Single(x => x.Id.Equals(id)).ToDto();
            });

            return item;
        }
        public IEnumerable<ItemDto> GetItems()
        {
            var result = new ItemDto[] { };

            WithContext(context =>
            {
                result = context.Items
                .Select(x => new ItemDto
                {
                    Id = x.Id,
                    Product = new ProductDto
                    {
                        Id = x.Product.Id,
                        Name = x.Product.Name,
                        Description = x.Product.Description,
                        Logo = x.Product.Logo,
                        Price = x.Product.Price,
                        Currency = x.Product.Currency,
                        Manufacturer = new ManufacturerDto
                        {
                            Id = x.Product.Manufacturer.Id,
                            Name = x.Product.Manufacturer.Name,
                            Logo = x.Product.Manufacturer.Logo
                        },
                        Category = new CategoryDto
                        {
                            Id = x.Product.Manufacturer.Id,
                            Name = x.Product.Manufacturer.Name,
                        },
                    },
                    Order = new OrderDto
                    {
                        Id = x.Order.Id,
                        User = new UserDto
                        {
                            Id = x.Order.User.Id,
                            Login = x.Order.User.Login,
                            Password = x.Order.User.Password,
                            Email = x.Order.User.Email,

                        },
                        Number = x.Order.Number
                    },
                    Quantity = x.Quantity,
                    Status = x.Status,
                }).ToArray();
            });

            return result;
        }

        public void Update(ItemDto model)
        {
            WithContext(context =>
            {
                var item = context.Items.Single(x => x.Id.Equals(model.Id));

                item.Id = model.Id;
                item.ProductId = model.Product.Id;
                item.OrderId = model.Order.Id;
                item.Quantity = model.Quantity;
                item.Status = model.Status;

                context.SaveChanges();
            });
        }
    }
}
