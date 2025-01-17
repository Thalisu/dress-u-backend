using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = dress_u_backend.models;

namespace dress_u_backend.Dtos.Category
{
    public class CreateCategoryRequestDto
    {
        public string Type { get; set; } = "";
    }
}