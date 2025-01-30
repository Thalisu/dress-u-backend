using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Models;

namespace dress_u_backend.Models
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "float(1, 2)")]
        public float Discount { get; set; }
        public string[] Images { get; set; } = [];
        public int Stock { get; set; }
        public Description Description { get; set; } = null!;
        public ICollection<CategoryCloth> CategoryCloths { get; set; } = [];
    }
}
