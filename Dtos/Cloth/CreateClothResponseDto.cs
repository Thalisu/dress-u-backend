using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Description;

namespace dress_u_backend.Dtos.Cloth
{
    public class CreateClothResponseDto

    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public float Discount { get; set; }
        public string[] Images { get; set; } = [];
        public int Stock { get; set; }
        public List<int> CategoryIds { get; set; } = [];
        public DescriptionDto Description { get; set; } = null!;
    }

}