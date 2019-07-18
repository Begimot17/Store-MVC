﻿using OnlineStore.BLL.Dtos.Category;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryViewModel ToViewModel(this CategoryBllDto model)
        {
            return new CategoryViewModel
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static CategoryBllDto ToDto(this CategoryViewModel model)
        {
            return new CategoryBllDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static IEnumerable<CategoryViewModel> ToViewModel(this IEnumerable<CategoryBllDto> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static IEnumerable<CategoryBllDto> ToViewModel(this IEnumerable<CategoryViewModel> models)
        {
            return models.Select(x => x.ToViewModel());
        }

        public static CategoryBllDto ToViewModel(this CategoryViewModel model)
        {
            return new CategoryBllDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}