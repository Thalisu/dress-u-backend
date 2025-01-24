using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.interfaces;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Controllers
{
    [Route("/cloths")]
    [ApiController]
    public class ClothController : ControllerBase
    {
        private readonly IClothRepository _clothRepo;
        private readonly ICategoryClothRepository _categoryClothRepo;
        private readonly IDescriptionRepository _descriptionRepo;
        public ClothController(IClothRepository clothRepo, ICategoryClothRepository categoryClothRepo, IDescriptionRepository descriptionRepository)
        {
            _clothRepo = clothRepo;
            _categoryClothRepo = categoryClothRepo;
            _descriptionRepo = descriptionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cloths = await _clothRepo.GetAllAsync();

            var clothsDto = cloths.Select(c =>
            {
                return c.ToClothDto();
            });

            return Ok(clothsDto);
        }

        [HttpGet("{id:int}")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateClothRequestDto clothDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var cloth = clothDto.ToClothFromCreateDto();
            await _clothRepo.CreateAsync(cloth, false);

            var categoryClothsDto = cloth.ToCreateCategoryClothDtoFromCategoryIds(clothDto.CategoryIds);
            var categoryCloths = await _categoryClothRepo.CreateAsync(categoryClothsDto, false);
            if (categoryCloths == null)
            {
                return BadRequest("CategoryCloth not created");
            }

            var description = await _descriptionRepo.CreateAsync(clothDto.DescriptionDto.ToDescriptionFromCreateDto(cloth.Id));
            if (description == null)
            {
                return BadRequest("Description not created");
            }

            return CreatedAtAction(nameof(GetById), new { id = cloth.Id }, cloth.ToResponseDtoFromCloth());
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClothRequestDto clothDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cloth = await _clothRepo.UpdateAsync(id, clothDto, false);
            if (cloth == null)
            {
                return NotFound();
            }

            var categoryClothsDto = cloth.ToUpdateCategoryClothDtoFromCategoryIds(clothDto.CategoryIds);
            await _categoryClothRepo.UpdateAsync(categoryClothsDto, false);

            var description = await _descriptionRepo.UpdateAsync(id, clothDto.Description);
            if (description == null)
            {
                return NotFound("Description not found");
            }

            return Ok(cloth);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
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