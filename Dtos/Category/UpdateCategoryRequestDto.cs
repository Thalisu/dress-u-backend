using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Cloth;

namespace dress_u_backend.Dtos.Category
{
    public class UpdateCategoryRequestDto
    {
        public List<ClothDto> Cloths { get; set; } = [];
        public string Type { get; set; } = "";
    }
}