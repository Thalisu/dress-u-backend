using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Controllers
{
    [Route("/cloths")]
    [ApiController]
    public class ClothController(IClothRepository clothRepo) : ControllerBase
    {
        private readonly IClothRepository _clothRepo = clothRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cloths = await _clothRepo.GetAllAsync();
            var clothDto = cloths.Select(c => c.ToClothDto());
            return Ok(clothDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cloth = await _clothRepo.GetByIdAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }

            return Ok(cloth);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClothRequestDto clothDto)
        {
            var allCategoriesExists = await Task.WhenAll(clothDto.Categories.Select(c => _clothRepo.CategoryExists(c.Id)));
            if (!allCategoriesExists.All(exists => exists))
            {
                return BadRequest("One or more categories do not exist.");
            }
            var cloth = clothDto.ToClothFromCreateDto();
            await _clothRepo.CreateAsync(cloth);
            return CreatedAtAction(nameof(GetById), new { id = cloth.Id }, cloth.ToClothDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClothRequestDto clothDto)
        {
            if (clothDto.Categories != null)
            {
                var allCategoriesExists = await Task.WhenAll(clothDto.Categories.Select(c => _clothRepo.CategoryExists(c.Id)));
                if (!allCategoriesExists.All(exists => exists))
                {
                    return BadRequest("One or more categories do not exist.");
                }
            }

            var cloth = await _clothRepo.UpdateAsync(id, clothDto);
            if (cloth == null)
            {
                return NotFound();
            }

            return Ok(cloth);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cloth = await _clothRepo.DeleteAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}