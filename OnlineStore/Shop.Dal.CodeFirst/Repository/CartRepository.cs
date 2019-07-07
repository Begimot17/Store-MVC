using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class CartRepository:ICartRepository
    {
        private List<CartViewModel> lineCollection = new List<CartViewModel>();

        public void AddItem(ProductDto product, int quantity)
        {
            CartViewModel line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartViewModel
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductDto product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartViewModel> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartViewModel
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
