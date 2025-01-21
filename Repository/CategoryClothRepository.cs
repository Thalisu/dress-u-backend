using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.models;
using dress_u_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Repository
{
    public class CategoryClothRepository(ApplicationDBContext context) : ICategoryClothRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<CategoryCloth>> CreateAsync(List<CategoryCloth> categoryCloths)
        {
            await _context.CategoryCloths.AddRangeAsync(categoryCloths);
            await _context.SaveChangesAsync();
            return categoryCloths;
        }

        public async Task<List<CategoryOnlyDto?>> GetClothCategoriesByClothId(int clothId)
        {
            return await _context.CategoryCloths.Where(cc => cc.ClothId == clothId)
                .Select(cc => cc.Category != null ? cc.Category.ToCategoryDto() : null)
                .ToListAsync();
        }
    }
}