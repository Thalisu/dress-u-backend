using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.models;
using dress_u_backend.Models;

namespace dress_u_backend.Interfaces
{
    public interface ICategoryClothRepository
    {
        Task<List<CategoryOnlyDto?>> GetClothCategoriesByClothId(int clothId);
        Task<List<CategoryCloth>> CreateAsync(List<CategoryCloth> categoryCloths);
    }
}