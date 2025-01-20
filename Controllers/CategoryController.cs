using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Category;
using dress_u_backend.interfaces;
using dress_u_backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dress_u_backend.Controllers
{
    [Route("/categories")]
    [ApiController]
    public class CategoryController(ICategoryRepository categoryRepo) : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo = categoryRepo;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoryDto = categories.Select(c => c.ToCategoryDto());
            return Ok(categoryDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var category = categoryDto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category.ToCategoryDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto categoryDto)
        {
            var category = await _categoryRepo.UpdateAsync(id, categoryDto);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _categoryRepo.DeleteAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}