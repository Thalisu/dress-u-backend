using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Dtos.Description;
using dress_u_backend.models;
using Humanizer;
using Newtonsoft.Json;

namespace dress_u_backend.Mappers
{
    public static class ClothMapper
    {
        public static ClothDto ToClothDto(this Cloth cloth)
        {
            return new ClothDto
            {
                Id = cloth.Id,
                Title = cloth.Title,
                Price = cloth.Price,
                Discount = cloth.Discount,
                Images = cloth.Images,
                Categories = [.. cloth.CategoryCloths.Select(cc => cc.Category?.ToCategoryDto())],
            };
        }
        public static CreateClothResponseDto ToResponseDtoFromCloth(this Cloth cloth)
        {
            return new CreateClothResponseDto
            {
                Id = cloth.Id,
                Title = cloth.Title,
                Price = cloth.Price,
                Discount = cloth.Discount,
                Images = cloth.Images,
                CategoryIds = [.. cloth.CategoryCloths.Select(cc => cc.CategoryId)],
                Description = cloth.Description?.ToDescriptionDto() ?? new DescriptionDto()
            };
        }

        public static Cloth ToClothFromCreateDto(this CreateClothRequestDto clothDto)
        {
            return new Cloth
            {
                Title = clothDto.Title,
                Price = clothDto.Price,
                Discount = clothDto.Discount,
                Images = clothDto.Images,
            };
        }
        public static Cloth ToClothFromUpdateDto(this UpdateClothRequestDto clothDto)
        {
            return new Cloth
            {
                Title = clothDto.Title,
                Price = clothDto.Price,
                Discount = clothDto.Discount,
                Images = clothDto.Images,
            };
        }
    }
}