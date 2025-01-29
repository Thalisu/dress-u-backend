using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.models;

namespace dress_u_backend.interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<Category?> DeleteAsync(int id);
    }
}