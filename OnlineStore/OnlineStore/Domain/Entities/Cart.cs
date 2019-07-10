using OnlineStore.Models;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(ProductDto product, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
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

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}