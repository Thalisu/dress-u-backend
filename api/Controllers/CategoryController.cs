using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Dtos.Category;
using dress_u_backend.interfaces;
using dress_u_backend.Mappers;
using Microsoft.AspNetCore.Authorization;
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
            var result = await _categoryRepo.GetAllAsync();

            return result
                .Match<IActionResult>(Ok, error => BadRequest(error.Message));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _categoryRepo.GetByIdAsync(id);

            return result
                .Match<IActionResult>(Ok, error => BadRequest(error.Message));
        }
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = categoryDto.ToCategoryFromCreateDto();
            var result = await _categoryRepo.CreateAsync(category);

            return result.Match<IActionResult>(
                categoryDto => CreatedAtAction(
                    nameof(GetById), new { id = categoryDto.Id }, categoryDto),
                error => BadRequest(error.Message));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _categoryRepo.UpdateAsync(id, categoryDto);

            return result
                .Match<IActionResult>(Ok, error => BadRequest(error.Message));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _categoryRepo.DeleteAsync(id);
            return result.Match<IActionResult>(
                _ => NoContent(),
                error => BadRequest(error.Message));
        }
    }
}