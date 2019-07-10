using Store.Dtos.Data.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Contracts
{
    public interface ICategoryRepository
    {
        void Create(CategoryDto model);

        CategoryDto GetCategory(Guid id);
        IEnumerable<CategoryDto> GetCategory();
    }
}
