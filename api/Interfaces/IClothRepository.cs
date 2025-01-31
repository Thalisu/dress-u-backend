using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Models;

namespace dress_u_backend.interfaces
{
    public interface IClothRepository
    {
        Task<Result<List<ClothDto>>> GetAllAsync();
        Task<Result<ClothDto>> GetByIdAsync(int id);
        Task<Result<ClothDto>> CreateAsync(CreateClothRequestDto cloth);
        Task<Result<ClothDto>> UpdateAsync(int id, UpdateClothRequestDto clothDto);
        Task<Result<ClothDto>> DeleteAsync(int id);
        Task<bool> ClothExists(int id);
    }
}