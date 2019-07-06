using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Entities
{
    public class Manufacturer:BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
