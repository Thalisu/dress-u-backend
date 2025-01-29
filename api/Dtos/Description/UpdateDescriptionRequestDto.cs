using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.Dtos.Description
{
    public class UpdateDescriptionRequestDto
    {
        [Required]
        public int ClothId { get; set; }
        [Required]
        [MinLength(10)]
        public string About { get; set; } = "";
        [Required]
        [MinLength(10)]
        public string Tecnical { get; set; } = "";
    }
}