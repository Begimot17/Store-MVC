using OnlineStore.Models;
using Store.Dtos.Data.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryViewModel ToViewModel(this CategoryDto model)
        {
            return new CategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static CategoryDto ToDto(this CategoryViewModel model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static IEnumerable<CategoryViewModel> ToViewModel(this IEnumerable<CategoryDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<CategoryDto> ToViewModel(this IEnumerable<CategoryViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static CategoryDto ToViewModel(this CategoryViewModel model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}