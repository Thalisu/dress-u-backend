using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Data;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.CategoryCloth;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Repository
{
    public class CategoryClothRepository(ApplicationDBContext context) : ICategoryClothRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<CategoryOnlyDto?>> GetClothCategoriesByClothId(int clothId)
        {
            return await _context.CategoryCloths.Where(cc => cc.ClothId == clothId)
                .Select(cc => cc.Category != null ? cc.Category.ToCategoryDto() : null)
                .ToListAsync();
        }
        public async Task<CreateCategoryClothRequestDto?> CreateAsync(CreateCategoryClothRequestDto categoryClothDto, bool save = true)
        {
            var categoryCloths = categoryClothDto.ToCategoryClothFromCreateDto();
            await _context.CategoryCloths.AddRangeAsync(categoryCloths);
            if (save) await _context.SaveChangesAsync();
            return categoryClothDto;
        }


        public async Task<UpdateCategoryClothRequestDto?> UpdateAsync(UpdateCategoryClothRequestDto categoryClothDto, bool save = true)
        {
            var CategoryClothModels = categoryClothDto.ToCategoryClothFromUpdateDto();
            var ExistingCategories = await _context.CategoryCloths.Where(cc => cc.ClothId == categoryClothDto.ClothId).ToListAsync();
            _context.CategoryCloths.RemoveRange(ExistingCategories);
            await _context.CategoryCloths.AddRangeAsync(CategoryClothModels);
            if (save) await _context.SaveChangesAsync();
            return categoryClothDto;
        }
    }
}
