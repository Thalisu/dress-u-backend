using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.Models
{
    public class Description
    {
        public int Id { get; set; }
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; } = null!;
        public string About { get; set; } = "";
        public string Tecnical { get; set; } = "";
    }
}