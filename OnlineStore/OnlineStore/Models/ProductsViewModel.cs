using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ProductsViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}