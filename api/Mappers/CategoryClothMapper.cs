using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.CategoryCloth;
using dress_u_backend.Models;

namespace dress_u_backend.Mappers
{
    public static class CategoryClothMapper
    {
        public static CreateCategoryClothRequestDto ToCreateCategoryClothDtoFromCategoryIds(this Cloth cloth, List<int> categoryIds)
        {
            return new CreateCategoryClothRequestDto
            {
                ClothId = cloth.Id,
                CategoryIds = categoryIds
            };
        }
        public static UpdateCategoryClothRequestDto ToUpdateCategoryClothDtoFromCategoryIds(this Cloth cloth, List<int> categoryIds)
        {
            return new UpdateCategoryClothRequestDto
            {
                ClothId = cloth.Id,
                CategoryIds = categoryIds
            };
        }
        public static List<CategoryCloth> ToCategoryClothFromCreateDto(this CreateCategoryClothRequestDto categoryClothDto)
        {
            return [.. categoryClothDto.CategoryIds.Select(
                    cId => new CategoryCloth
                        { CategoryId = cId, ClothId = categoryClothDto.ClothId}
                  )];
        }
        public static List<CategoryCloth> ToCategoryClothFromUpdateDto(this UpdateCategoryClothRequestDto categoryClothDto)
        {
            return [.. categoryClothDto.CategoryIds.Select(
                    cId => new CategoryCloth
                        { CategoryId = cId, ClothId = categoryClothDto.ClothId}
                  )];
        }

        public static CategoryCloth ToCategoryClothFromCloth(this Cloth cloth, int categoryId)
        {
            return new CategoryCloth
            {
                CategoryId = categoryId,
                ClothId = cloth.Id
            };
        }
        public static CategoryCloth ToCategoryClothFromCategory(this Category category, int clothId)
        {
            return new CategoryCloth
            {
                CategoryId = category.Id,
                ClothId = clothId
            };
        }
        /*         public static CategoryCloth ToCategoryClothFromUpdateDto(this UpdateCategoryClothRequestDto categoryClothRequestDto)
                {
                    return new CategoryCloth
                    {
                        CategoryId = categoryClothRequestDto.CategoryId,
                        ClothId = categoryClothRequestDto.ClothId
                    };
                } */
    }
}