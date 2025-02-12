using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Common.Errors;
using dress_u_backend.Data;
using dress_u_backend.Data.Queries;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Dtos.Description;
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

        public async Task<Result<List<CategoryDto>>> GetAllAsync()
        {

            List<CategoryDto> categories = await _context.Categories
                .ToCategoryDtoQuery()
                .ToListAsync();

            return categories;
        }
        public async Task<Result<CategoryDto>> GetByIdAsync(int id)
        {
            CategoryDto? category = await _context.Categories
                .Where(c => c.Id == id)
                .ToCategoryDtoQuery(
                    includeCloth: true,
                    includeDescription: true,
                    includeCategory: true).FirstOrDefaultAsync();

            if (category == null)
            {
                return ApiErrors.NotFound("Category", id);
            }

            return category;
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
                return ApiErrors.NotFound("Category", id);
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
                return ApiErrors.NotFound("Category", id);
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}