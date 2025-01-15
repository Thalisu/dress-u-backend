using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dress_u_backend.models
{
    public class Category
    {
        public int Id { get; set; }
        public List<Cloth> Cloths { get; } = [];
        public string Type { get; set; } = "";
    }
}