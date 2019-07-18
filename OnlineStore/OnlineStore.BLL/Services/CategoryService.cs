using OnlineStore.BLL.Contracts.Category;
using OnlineStore.BLL.Dtos.Category;
using Store.Dal.CodeFirst.Contracts;
using Store.Dtos.Data.Category;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        private CategoryDto ToData(CategoryBllDto model)
        {
            return new CategoryDto
            {
                Id=model.Id,
                Name=model.Name
            };
        }
        private CategoryBllDto ToBusiness(CategoryDto model)
        {
            return new CategoryBllDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public void Create(CategoryBllDto model)
        {
            _categoryRepository.Create(ToData(model));
        }

        public CategoryBllDto GetCategory(Guid id)
        {
            return ToBusiness(_categoryRepository.GetCategory(id));
        }

        public IEnumerable<CategoryBllDto> GetCategory() =>
            _categoryRepository.GetCategory().Select(ToBusiness);
    }
}
