using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.models;
using dress_u_backend.Models;

namespace dress_u_backend.Mappers
{
    public static class CategoryClothMapper
    {
        public static CategoryCloth ToCategoryCloth(int categoryId, int clothId)
        {
            return new CategoryCloth
            {
                CategoryId = categoryId,
                ClothId = clothId
            };
        }
    }
}