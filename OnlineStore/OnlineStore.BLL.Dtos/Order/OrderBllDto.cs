using OnlineStore.BLL.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Dtos.Order
{
    public class OrderBllDto
    {
        public Guid Id { get; set; }
        public virtual UserBllDto User { get; set; }
        public string Number { get; set; }
    }
}
