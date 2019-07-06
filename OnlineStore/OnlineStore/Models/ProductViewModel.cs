
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Currency { get; set; }
        public int Price { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        public virtual ManufacturerViewModel Manufacturer { get; set; }
    }
}