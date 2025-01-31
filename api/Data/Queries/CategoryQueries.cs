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
    public static class CategoryQueries
    {
        public static IQueryable<CategoryDto> ToCategoryDtoQuery(
            this IQueryable<Category> query,
            bool includeCloth = false,
            bool includeDescription = false,
            bool includeCategory = false)
        {
            return query.Select(c => new CategoryDto
            {
                Id = c.Id,
                Type = c.Type,
                Cloths = includeCloth ? c.CategoryCloths.Select(cc => new ClothDto
                {
                    Id = cc.Cloth.Id,
                    Title = cc.Cloth.Title,
                    Price = cc.Cloth.Price,
                    Discount = cc.Cloth.Discount,
                    Images = cc.Cloth.Images,
                    Stock = cc.Cloth.Stock,
                    Description = includeDescription ? new DescriptionDto
                    {
                        About = cc.Cloth.Description.About,
                        Tecnical = cc.Cloth.Description.Tecnical
                    } : null,
                    Categories = includeCategory ? cc.Cloth.CategoryCloths.Select(ccc => new CategoryDto
                    {
                        Id = ccc.Category.Id,
                        Type = ccc.Category.Type
                    }).ToList() : null
                }).ToList() : null
            });
        }
    }
}