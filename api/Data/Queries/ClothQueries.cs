using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Dtos.Description;
using dress_u_backend.Models;

namespace dress_u_backend.Data.Queries
{
    public static class ClothQueries
    {
        public static IQueryable<ClothDto> ToClothDtoQuery(
            this IQueryable<Cloth> query,
            bool includeDescription = false,
            bool includeCategory = false)
        {
            return query.Select(c => new ClothDto
            {
                Id = c.Id,
                Title = c.Title,
                Price = c.Price,
                Discount = c.Discount,
                Images = c.Images,
                Description = includeDescription ? new DescriptionDto
                {
                    About = c.Description.About,
                    Tecnical = c.Description.Tecnical
                } : null,
                Categories = includeCategory ? c.CategoryCloths.Select(cc => new CategoryDto
                {
                    Id = cc.Category.Id,
                    Type = cc.Category.Type
                }).ToList() : null
            });
        }
    }
}