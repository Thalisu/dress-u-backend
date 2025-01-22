using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Interfaces;
using dress_u_backend.models;

namespace dress_u_backend.Repository
{
    public class DescriptionRepository(ApplicationDBContext context) : IDescriptionRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Description> CreateAsync(Description description)
        {
            await _context.Description.AddAsync(description);
            await _context.SaveChangesAsync();
            return description;
        }
    }
}