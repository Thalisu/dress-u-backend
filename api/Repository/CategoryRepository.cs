using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Common.Errors;
using dress_u_backend.Data;
using dress_u_backend.Dtos.Category;
using dress_u_backend.interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Repository
{
    public class CategoryRepository(ApplicationDBContext context)
        : ICategoryRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Result<CategoriesDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new CategoriesDto
            {
                Categories = [.. categories.Select(c => c.ToCategoryDto())]
            };
        }
        public async Task<Result<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.CategoryCloths)
                    .ThenInclude(cc => cc.Cloth)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return ApiErrors.NotFound("Category");
            }

            return category.ToCategoryDto();
        }
        public async Task<Result<CategoryDto>> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.ToCategoryDto();
        }
        public async Task<Result<CategoryDto>> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromUpdateDto();
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return ApiErrors.NotFound("Category");
            }

            existingCategory.Type = categoryModel.Type;
            await _context.SaveChangesAsync();
            return existingCategory.ToCategoryDto();
        }
        public async Task<Result<Category>> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return ApiErrors.NotFound("Category");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}