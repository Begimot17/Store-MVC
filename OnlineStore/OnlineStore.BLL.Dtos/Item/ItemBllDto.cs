using OnlineStore.BLL.Dtos.Order;
using OnlineStore.BLL.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Dtos.Item
{
    public class ItemBllDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public virtual ProductBllDto Product { get; set; }
        public virtual OrderBllDto Order { get; set; }
        public int Quantity { get; set; }
        public decimal AllPrice { get; set; }
        public string Status { get; set; }

    }
}
