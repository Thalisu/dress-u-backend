using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Dtos.Category;
using dress_u_backend.Dtos.CategoryCloth;
using dress_u_backend.Dtos.Description;
using dress_u_backend.Models;

namespace dress_u_backend.Interfaces
{
    public interface ICategoryClothRepository
    {
        Task<Result<CategoriesDto>> GetByClothId(int clothId);
        Task<Result<CreateCategoryClothRequestDto>> CreateAsync(
            CreateCategoryClothRequestDto categoryClothDto);
        Task<Result<UpdateCategoryClothRequestDto>> UpdateAsync(
            UpdateCategoryClothRequestDto categoryClothDto);
    }
}