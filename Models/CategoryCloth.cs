using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.models;

namespace dress_u_backend.Models
{
    public class CategoryCloth
    {
        public Category? Category { get; set; }
        public Cloth? Cloth { get; set; }
        public int CategoryId { get; set; }
        public int ClothId { get; set; }
    }
}