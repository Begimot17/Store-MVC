using Store.Dtos.Data.Category;
using Store.Dtos.Data.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dtos.Data.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Currency { get; set; }
        public int Price { get; set; }
        public virtual CategoryDto Category { get; set; }
        public virtual ManufacturerDto Manufacturer { get; set; }
    }
}
