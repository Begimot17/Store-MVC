using Store.Dtos.Data.Order;
using Store.Dtos.Data.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dtos.Data.Item
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual OrderDto Order { get; set; }
        public int Quantity { get; set; }
        public decimal AllPrice { get; set; }
        public string Status { get; set; }

    }
}
