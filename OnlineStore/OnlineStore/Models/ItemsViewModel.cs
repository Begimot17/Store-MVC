using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ItemsViewModel
    {
        public IEnumerable<ItemViewModel> items { get; set; }
    }
}