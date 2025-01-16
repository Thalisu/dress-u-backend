using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Cloth;
using dress_u_backend.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var products = _context.Cloths.ToList().Select(c => c.ToClothDto());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _context.Cloths.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToClothDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateClothRequestDto clothDto)
        {
            var cloth = clothDto.ToClothFromCreateDto();
            _context.Cloths.Add(cloth);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = cloth.Id }, cloth.ToClothDto());
        }
    }
}