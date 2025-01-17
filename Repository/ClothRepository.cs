using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.models;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Repository
{
    public class ClothRepository : IClothRepository
    {
        private readonly ApplicationDBContext _context;
        public ClothRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Cloth>> GetAllAsync()
        {
            return await _context.Cloths.ToListAsync();
        }
        public async Task<ClothDto?> GetByIdAsync(int id)
        {
            var cloth = await _context.Cloths.FindAsync(id);
            return cloth?.ToClothDto();
        }
        public async Task<Cloth> CreateAsync(Cloth cloth)
        {
            await _context.Cloths.AddAsync(cloth);
            await _context.SaveChangesAsync();
            return cloth;
        }
        public async Task<ClothDto?> UpdateAsync(int id, UpdateClothRequestDto clothDto)
        {
            var clothModel = clothDto.ToClothFromUpdateDto();
            var existingCloth = await _context.Cloths.FindAsync(id);
            if (existingCloth == null)
            {
                return null;
            }

            existingCloth.Title = clothModel.Title;
            existingCloth.Price = clothModel.Price;
            existingCloth.Discount = clothModel.Discount;
            existingCloth.Images = clothModel.Images;
            existingCloth.Categories = clothModel.Categories;
            existingCloth.Description = clothModel.Description;
            await _context.SaveChangesAsync();
            return existingCloth.ToClothDto();
        }
        public async Task<Cloth?> DeleteAsync(int id)
        {
            var cloth = await _context.Cloths.FindAsync(id);
            if (cloth == null)
            {
                return null;
            }

            _context.Cloths.Remove(cloth);
            await _context.SaveChangesAsync();
            return cloth;
        }
    }
}