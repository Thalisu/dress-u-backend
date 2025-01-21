using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Models;

namespace dress_u_backend.models
{
    public class Category
    {
        public int Id { get; set; }
        public ICollection<CategoryCloth> CategoryCloths { get; set; } = [];
        public string Type { get; set; } = "";
    }
}