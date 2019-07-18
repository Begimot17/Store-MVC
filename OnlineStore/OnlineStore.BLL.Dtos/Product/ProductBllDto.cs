using OnlineStore.BLL.Dtos.Category;
using OnlineStore.BLL.Dtos.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Dtos.Product
{
    public class ProductBllDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Currency { get; set; }
        public int Price { get; set; }
        public virtual CategoryBllDto Category { get; set; }
        public virtual ManufacturerBllDto Manufacturer { get; set; }
    }
}
