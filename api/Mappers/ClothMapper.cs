using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Dtos.Description;
using dress_u_backend.Models;
using Humanizer;
using Newtonsoft.Json;

namespace dress_u_backend.Mappers
{
    public static class ClothMapper
    {
        public static ClothDto ToClothDto(this Cloth cloth)
        {
            return new()
            {
                Id = cloth.Id,
                Title = cloth.Title,
                Price = cloth.Price,
                Discount = cloth.Discount,
                Images = cloth.Images,
                Description = cloth.Description?.ToDescriptionDto(),
                Categories = cloth.CategoryCloths == null ? null
                    : [.. cloth.CategoryCloths.Select(cc => new CategoryDto
                    {
                        Id = cc.Category.Id,
                        Type = cc.Category.Type
                    })]
            };
        }
        public static ClothDto ToClothDtoFromCreate(
            this CreateClothRequestDto clothDto, int id)
        {
            return new()
            {
                Id = id,
                Title = clothDto.Title,
                Price = clothDto.Price,
                Discount = clothDto.Discount,
                Images = clothDto.Images,
                Stock = clothDto.Stock,
                Description = new()
                {
                    About = clothDto.Description.About,
                    Tecnical = clothDto.Description.Tecnical
                },
                Categories = [.. clothDto.CategoryIds.Select( id => new CategoryDto
                {
                    Id = id,
                }
                )]
            };
        }
        public static ClothDto ToClothDtoFromUpdate(
            this UpdateClothRequestDto clothDto, int id)
        {
            return new()
            {
                Id = id,
                Title = clothDto.Title,
                Price = clothDto.Price,
                Discount = clothDto.Discount,
                Images = clothDto.Images,
                Stock = clothDto.Stock,
                Description = new()
                {
                    About = clothDto.Description.About,
                    Tecnical = clothDto.Description.Tecnical
                },
                Categories = [.. clothDto.CategoryIds.Select( id => new CategoryDto
                {
                    Id = id,
                }
                )]
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
                Stock = clothDto.Stock,
                CategoryCloths = [.. clothDto.CategoryIds.Select(
                    categoryId => new CategoryCloth{
                        CategoryId = categoryId,
                    }
                )],
                Description = new Description
                {
                    About = clothDto.Description.About,
                    Tecnical = clothDto.Description.Tecnical
                }
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
                Stock = clothDto.Stock,
                CategoryCloths = [.. clothDto.CategoryIds.Select(
                    categoryId => new CategoryCloth{
                        CategoryId = categoryId,
                    }
                )],
                Description = new Description
                {
                    About = clothDto.Description.About,
                    Tecnical = clothDto.Description.Tecnical
                }
            };
        }
    }
}