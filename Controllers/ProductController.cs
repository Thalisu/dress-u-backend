using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Controllers
{
    [Route("/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cloths = await _context.Cloths.ToListAsync();
            var clothDto = cloths.Select(c => c.ToClothDto());
            return Ok(clothDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _context.Cloths.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToClothDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClothRequestDto clothDto)
        {
            var cloth = clothDto.ToClothFromCreateDto();
            await _context.Cloths.AddAsync(cloth);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = cloth.Id }, cloth.ToClothDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClothRequestDto clothDto)
        {
            var cloth = await _context.Cloths.FindAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }

            cloth.Title = clothDto.Title;
            cloth.Price = clothDto.Price;
            cloth.Discount = clothDto.Discount;
            cloth.Images = clothDto.Images;
            cloth.Categories = clothDto.Categories;
            cloth.Description = clothDto.Description;
            await _context.SaveChangesAsync();

            return Ok(cloth.ToClothDto());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cloth = await _context.Cloths.FirstOrDefaultAsync(x => x.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            _context.Cloths.Remove(cloth);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}