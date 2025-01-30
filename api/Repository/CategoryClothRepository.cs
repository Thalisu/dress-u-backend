using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Common.Errors;
using dress_u_backend.Data;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.CategoryCloth;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Repository
{
    public class CategoryClothRepository(ApplicationDBContext context)
        : ICategoryClothRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Result<List<CategoryDto>>> GetByClothId(int clothId)
        {
            List<CategoryDto> categories = await _context.CategoryCloths
                .Where(cc => cc.ClothId == clothId)
                .Select(cc => cc.Category.ToCategoryDto()).ToListAsync();

            if (categories.Count == 0)
            {
                return ApiErrors.NotFound("Categories");
            }


            return categories;
        }
        public async Task<Result<CreateCategoryClothRequestDto>> CreateAsync(
            CreateCategoryClothRequestDto categoryClothDto)
        {
            var categoryCloths = categoryClothDto.ToCategoryClothFromCreateDto();
            await _context.CategoryCloths.AddRangeAsync(categoryCloths);

            await _context.SaveChangesAsync();

            return categoryClothDto;
        }


        public async Task<Result<UpdateCategoryClothRequestDto>> UpdateAsync(
            UpdateCategoryClothRequestDto categoryClothDto)
        {
            var CategoryClothModels = categoryClothDto
                .ToCategoryClothFromUpdateDto();

            var ExistingCategories = await _context.CategoryCloths.Where(
                cc => cc.ClothId == categoryClothDto.ClothId).ToListAsync();

            _context.CategoryCloths.RemoveRange(ExistingCategories);
            await _context.CategoryCloths.AddRangeAsync(CategoryClothModels);

            await _context.SaveChangesAsync();

            return categoryClothDto;
        }
    }
}
