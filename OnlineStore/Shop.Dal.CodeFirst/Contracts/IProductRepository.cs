using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface IProductRepository
    {
        void Create(ProductDto model);
        void Update(ProductDto model);
        void Delete(Guid id);
        ProductDto GetProduct(Guid id);
        IEnumerable<ProductDto> GetProducts();
    }
}
