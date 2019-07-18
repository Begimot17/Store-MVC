using OnlineStore.BLL.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Contracts.Category
{
    public interface ICategoryService
    {
        void Create(CategoryBllDto model);
        CategoryBllDto GetCategory(Guid id);
        IEnumerable<CategoryBllDto> GetCategory();
    }
}
