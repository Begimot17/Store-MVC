using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Entities
{
    public enum StatusEnum
    {
        Cart,
        Purchase,
        Requested,
        Approved,
        Realeased
    };
    public class Item:BaseEntity
    {
        public Guid? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public Guid? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal AllPrice { get; set; }
        public string Status { get; set; }

    }
}
