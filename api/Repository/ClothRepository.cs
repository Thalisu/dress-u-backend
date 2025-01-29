using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Data;
using dress_u_backend.Dtos.Cloth;
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

        public async Task<List<Cloth>> GetAllAsync()
        {
            var cloths = await _context.Cloths
                .Include(c => c.Description)
                .Include(c => c.CategoryCloths)
                    .ThenInclude(cc => cc.Category)
                .ToListAsync();
            return cloths;
        }
        public async Task<ClothDto?> GetByIdAsync(int id)
        {
            var cloth = await _context.Cloths
                .Include(c => c.Description)
                .Include(c => c.CategoryCloths)
                    .ThenInclude(cc => cc.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
            return cloth?.ToClothDto();
        }
        public async Task<Cloth?> CreateAsync(Cloth cloth, bool save = true)
        {
            await _context.Cloths.AddAsync(cloth);
            if (save) await _context.SaveChangesAsync();
            return cloth;
        }
        public async Task<Cloth?> UpdateAsync(int id, UpdateClothRequestDto clothDto, bool save = true)
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
            existingCloth.Description = clothModel.Description;
            if (save) await _context.SaveChangesAsync();
            return existingCloth;
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
        public async Task<bool> ClothExists(int id)
        {
            return await _context.Cloths.AnyAsync(c => c.Id == id);
        }
    }
}