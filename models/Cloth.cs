using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [Column (TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column (TypeName = "float(1, 2)")]
        public float Discount { get; set; }
        public string[] Images { get; set; } = [];
    }
}
