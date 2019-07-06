using Store.Dtos.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dtos.Data.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public virtual UserDto User { get; set; }
        public string Number { get; set; }
    }
}
