using Store.Dal.CodeFirst.Contracts;
using Store.Dal.CodeFirst.Mappers;
using Store.Dtos.Data.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public void Create(CategoryDto model)
        {
            var entity = model.ToEntity();

            WithContext(context =>
            {
                context.Categories.Add(entity);
                context.SaveChanges();
            });
        }

        public CategoryDto GetCategory(Guid id)
        {
            CategoryDto categoryDto = null;
            WithContext(context =>
            {
                categoryDto = context.Categories.Single(x => x.Id.Equals(id)).ToDto();
            });

            return categoryDto;
        }

        public IEnumerable<CategoryDto> GetCategory()
        {
            var result = new CategoryDto[] { };

            WithContext(context =>
            {
                result = context.Categories 
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToArray();
            });

            return result;
        }
    }
}
