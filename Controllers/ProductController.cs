using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
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
            var products = _context.Cloths.ToList();
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

            return Ok(product);
        }
    }
}