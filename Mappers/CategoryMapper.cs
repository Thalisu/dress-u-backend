using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.models;

namespace dress_u_backend.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Type = category.Type,
                Cloths = [.. category.Cloths.Select(c => c.ToClothDto())],
            };
        }

        public static Category ToCategoryFromDto(this CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                Type = categoryDto.Type,
            };
        }

        public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                Type = categoryDto.Type,
            };
        }
        public static Category ToCategoryFromUpdateDto(this UpdateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                Type = categoryDto.Type,
            };
        }
    }
}