using Store.Dal.CodeFirst.Entities;
using Store.Dtos.Data.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.CodeFirst.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Category model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
              
            };
        }

        public static Category ToEntity(this CategoryDto model)
        {
            return new Category
            {
                Id = model.Id,
                Name = model.Name,
              
            };
        }
    }
}
