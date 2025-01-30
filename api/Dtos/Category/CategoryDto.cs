using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Cloth;

namespace dress_u_backend.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = "";
        public List<ClothDto>? Cloths { get; set; } = null;
    }
}