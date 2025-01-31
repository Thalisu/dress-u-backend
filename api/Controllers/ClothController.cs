using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dress_u_backend.Data;
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
    public class ClothController(IClothRepository clothRepo) : ControllerBase
    {
        private readonly IClothRepository _clothRepo = clothRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clothRepo.GetAllAsync();

            return result
                .Match<IActionResult>(Ok, error => BadRequest(error.Message));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _clothRepo.GetByIdAsync(id);

            return result
                .Match<IActionResult>(Ok, error => BadRequest(error.Message));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(
            [FromBody] CreateClothRequestDto clothDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _clothRepo.CreateAsync(clothDto);

            return result.Match<IActionResult>(
                clothDto => CreatedAtAction(
                    nameof(GetById), new { id = clothDto.Id }, clothDto),
                error => BadRequest(error.Message));
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateClothRequestDto clothDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _clothRepo.UpdateAsync(id, clothDto);

            return result
                .Match<IActionResult>(Ok, error => BadRequest(error.Message));
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _clothRepo.DeleteAsync(id);

            return result.Match<IActionResult>(
                _ => NoContent(),
                error => BadRequest(error.Message));
        }

        [HttpGet("test-role")]
        public IActionResult TestRole()
        {
            var user = HttpContext.User;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            return Ok(new { Roles = roles });
        }
    }
}