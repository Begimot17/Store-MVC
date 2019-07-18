using OnlineStore.BLL.Dtos.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts.Item
{
    public interface IItemService
    {
        void Create(ItemBllDto model);
        void Update(ItemBllDto model);
        void Delete(Guid id);
        ItemBllDto GetItem(Guid id);
        IEnumerable<ItemBllDto> GetItems();
    }
}
