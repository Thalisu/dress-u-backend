using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.models
{
    public class Category
    {
        public int Id { get; set; }
        public ICollection<Cloth> Cloths { get; set; } = [];
        public string Type { get; set; } = "";
    }
}