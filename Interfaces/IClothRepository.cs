using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.models;

namespace dress_u_backend.interfaces
{
    public interface IClothRepository
    {
        Task<List<Cloth>> GetAllAsync();
        Task<ClothDto?> GetByIdAsync(int id);
        Task<Cloth?> CreateAsync(Cloth cloth, bool save = true);
        Task<Cloth?> UpdateAsync(int id, UpdateClothRequestDto clothDto, bool save = true);
        Task<Cloth?> DeleteAsync(int id);
        Task<bool> ClothExists(int id);
    }
}