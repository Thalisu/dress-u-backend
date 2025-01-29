using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Cloth;

namespace dress_u_backend.Dtos.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Type must be at least 3 characters long")]
        [MaxLength(50, ErrorMessage = "Type must be at most 50 characters long")]
        public string Type { get; set; } = "";
    }
}