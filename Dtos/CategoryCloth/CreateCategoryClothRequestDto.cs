using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.Cloth;

namespace dress_u_backend.Dtos.CategoryCloth
{
    public class CreateCategoryClothRequestDto
    {
        public List<int> CategoryIds { get; set; } = [];
        public int ClothId { get; set; }
    }
}