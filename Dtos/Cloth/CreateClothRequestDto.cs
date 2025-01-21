using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;

namespace dress_u_backend.Dtos.Cloth
{
    public class CreateClothRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000")]
        public decimal Price { get; set; }
        [Range(0, 1, ErrorMessage = "Discount must be between 0 and 1")]
        public float Discount { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "At least one image is required")]
        public string[] Images { get; set; } = [];
        /*         public Models.Description? Description { get; set; } */
        [Required]
        [MinLength(1, ErrorMessage = "At least one category is required")]
        public List<int> CategoryIds { get; set; } = [];
    }
}