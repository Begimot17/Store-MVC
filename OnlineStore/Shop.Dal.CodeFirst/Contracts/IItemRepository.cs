using Store.Dtos.Data.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface IItemRepository
    {
        void Create(ItemDto model);
        void Update(ItemDto model);
        void Delete(Guid id);
        ItemDto GetItem(Guid id);
        IEnumerable<ItemDto> GetItems();
    }
}
