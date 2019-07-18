using OnlineStore.BLL.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts.Product
{
    public interface IProductService
    {
        void Create(ProductBllDto model);
        void Update(ProductBllDto model);
        void Delete(Guid id);
        ProductBllDto GetProduct(Guid id);
        IEnumerable<ProductBllDto> GetProducts();
    }
}
