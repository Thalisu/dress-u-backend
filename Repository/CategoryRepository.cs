using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Category;
using dress_u_backend.interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.models;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category?.ToCategoryDto();
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromUpdateDto();
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Type = categoryModel.Type;
            await _context.SaveChangesAsync();
            return existingCategory.ToCategoryDto();
        }
        public async Task<Category?> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}