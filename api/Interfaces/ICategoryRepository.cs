using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Models;

namespace dress_u_backend.interfaces
{
    public interface ICategoryRepository
    {
        Task<Result<CategoriesDto>> GetAllAsync();
        Task<Result<CategoryDto>> GetByIdAsync(int id);
        Task<Result<CategoryDto>> CreateAsync(Category category);
        Task<Result<CategoryDto>> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<Result<Category>> DeleteAsync(int id);
    }
}