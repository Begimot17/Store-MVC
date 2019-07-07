using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface ICartRepository
    {
        void AddItem(ProductDto product, int quantity);
        void RemoveLine(ProductDto product);
        decimal ComputeTotalValue();
        void Clear();
    }
}
