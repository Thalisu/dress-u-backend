using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Models;

namespace dress_u_backend.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            List<ClothDto> cloths = [.. category.CategoryCloths.Select(cc => cc.Cloth.ToClothDto())];
            return cloths.Count switch
            {
                > 0 => new CategoryDto
                {
                    Id = category.Id,
                    Type = category.Type,
                    Cloths = cloths,
                },
                _ => new CategoryDto
                {
                    Id = category.Id,
                    Type = category.Type,
                },
            };
        }

        public static Category ToCategoryFromUseDto(this UseCategoryDto categoryDto)
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