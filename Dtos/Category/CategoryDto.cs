using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = dress_u_backend.models;

namespace dress_u_backend.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public ICollection<Models.Cloth> Cloths { get; set; } = [];
        public string Type { get; set; } = "";
    }
}