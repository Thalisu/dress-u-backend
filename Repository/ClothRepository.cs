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
            var cloth = await _context.Cloths.FindAsync(id);
            if (cloth == null)
            {
                return null;
            }

            cloth.Title = clothDto.Title;
            cloth.Price = clothDto.Price;
            cloth.Discount = clothDto.Discount;
            cloth.Images = clothDto.Images;
            cloth.Categories = clothDto.Categories;
            cloth.Description = clothDto.Description;
            await _context.SaveChangesAsync();
            return cloth.ToClothDto();
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