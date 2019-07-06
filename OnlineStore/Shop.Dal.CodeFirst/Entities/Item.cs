using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Entities
{
    public class Item:BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
