using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public virtual UserViewModel User { get; set; }
        public string Number { get; set; }
    }
}