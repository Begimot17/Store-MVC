using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Entities
{
    public class Order:BaseEntity
    {
        public virtual User User { get; set; }
        public string Number { get; set; }
    }
}
