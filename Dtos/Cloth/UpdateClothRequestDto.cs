using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = dress_u_backend.models;

namespace dress_u_backend.Dtos.Cloth
{
    public class UpdateClothRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public string[] Images { get; set; } = [];
        public Models.Description? Description { get; set; }
        public ICollection<Models.Category> Categories { get; set; } = [];
    }
}