using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using OnlineStore.BLL.Services;
using OnlineStore.BLL.Contracts.User;
using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Repository;
using OnlineStore.BLL.Contracts.Product;
using OnlineStore.BLL.Contracts.Category;
using OnlineStore.BLL.Contracts.Item;
using OnlineStore.BLL.Contracts.Order;
using OnlineStore.BLL.Contracts.Manufacturer;

namespace OnlineStore.IOC
{
    public static class IocConfiguration
    {
        public static void Register(Assembly mvcAssebly)
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            builder.RegisterControllers(mvcAssebly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ItemRepository>().As<IItemRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ManufacturerRepository>().As<IManufacturerRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ItemService>().As<IItemService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ManufacturerService>().As<IManufacturerService>();
        }
    }
}
