using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.data;
using dress_u_backend.Dtos.Description;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.models;

namespace dress_u_backend.Repository
{
    public class DescriptionRepository(ApplicationDBContext context) : IDescriptionRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Description> CreateAsync(Description description, bool save = true)
        {
            await _context.Description.AddAsync(description);
            if (save) await _context.SaveChangesAsync();
            return description;
        }
        public async Task<DescriptionDto?> UpdateAsync(int clothId, UpdateDescriptionRequestDto descriptionDto, bool save = true)
        {

            var descriptionModel = descriptionDto.ToDescriptionFromUpdateDto(clothId);
            var existingDescription = _context.Description.FirstOrDefault(d => d.ClothId == clothId);

            if (existingDescription == null)
            {
                var description = await CreateAsync(descriptionModel);
                return description.ToDescriptionDto();
            }

            existingDescription.About = descriptionModel.About;
            existingDescription.Tecnical = descriptionModel.Tecnical;
            if (save) await _context.SaveChangesAsync();

            return existingDescription.ToDescriptionDto();

        }
    }
}