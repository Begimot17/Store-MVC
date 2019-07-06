using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public int Quantity { get; set; }
    }
}