using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.Cloth;

namespace dress_u_backend.Dtos.CategoryCloth
{
    public class CategoryClothDto
    {
        public CategoryDto? Category { get; set; }
        public ClothDto? Cloth { get; set; }
        public int CategoryId { get; set; }
        public int ClothId { get; set; }
    }
}