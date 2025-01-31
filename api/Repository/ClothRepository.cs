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
using Newtonsoft.Json;

namespace dress_u_backend.Repository
{
    public class ClothRepository(ApplicationDBContext context) : IClothRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Result<List<ClothDto>>> GetAllAsync()
        {
            List<ClothDto> cloths = await _context.Cloths
                .ToClothDtoQuery(includeCategory: true)
                .ToListAsync();

            return cloths;
        }
        public async Task<Result<ClothDto>> GetByIdAsync(int id)
        {
            ClothDto? cloth = await _context.Cloths
                .Where(c => c.Id == id)
                .ToClothDtoQuery(
                    includeCategory: true,
                    includeDescription: true)

                .FirstOrDefaultAsync();

            if (cloth == null)
            {
                return ApiErrors.NotFound("Cloth", id);
            }

            return cloth;
        }
        public async Task<Result<ClothDto>> CreateAsync(
            CreateClothRequestDto clothDto)
        {
            var cloth = clothDto.ToClothFromCreateDto();
            await _context.Cloths.AddAsync(cloth);
            await _context.SaveChangesAsync();
            return clothDto.ToClothDtoFromCreate(cloth.Id);
        }
        public async Task<Result<ClothDto>> UpdateAsync(int id, UpdateClothRequestDto clothDto)
        {
            var cloth = clothDto.ToClothFromUpdateDto();
            var existingCloth = await _context.Cloths.FindAsync(id);
            if (existingCloth == null)
            {
                return ApiErrors.NotFound("Cloth", id);
            }

            existingCloth.Title = cloth.Title;
            existingCloth.Price = cloth.Price;
            existingCloth.Discount = cloth.Discount;
            existingCloth.Images = cloth.Images;
            existingCloth.Description = cloth.Description;
            existingCloth.CategoryCloths = cloth.CategoryCloths;

            await _context.SaveChangesAsync();
            return clothDto.ToClothDtoFromUpdate(id);
        }
        public async Task<Result<ClothDto>> DeleteAsync(int id)
        {
            var cloth = await _context.Cloths.FindAsync(id);
            if (cloth == null)
            {
                return ApiErrors.NotFound("Cloth", id);
            }

            _context.Cloths.Remove(cloth);
            await _context.SaveChangesAsync();
            return cloth.ToClothDto();
        }
        public async Task<bool> ClothExists(int id)
        {
            return await _context.Cloths.AnyAsync(c => c.Id == id);
        }
    }
}