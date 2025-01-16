using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.models;
using Humanizer;

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
                Categories = cloth.Categories,
                Description = cloth.Description
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
                Categories = clothDto.Categories,
                Description = clothDto.Description,
            };
        }
    }
}