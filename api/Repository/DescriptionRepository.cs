using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Common;
using dress_u_backend.Data;
using dress_u_backend.Dtos.Description;
using dress_u_backend.Interfaces;
using dress_u_backend.Mappers;
using dress_u_backend.Models;

namespace dress_u_backend.Repository
{
    public class DescriptionRepository(ApplicationDBContext context) : IDescriptionRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Result<Description>> CreateAsync(Description description)
        {
            await _context.Description.AddAsync(description);
            await _context.SaveChangesAsync();
            return description;
        }
        public async Task<Result<DescriptionDto>> UpdateAsync(int clothId, UpdateDescriptionRequestDto descriptionDto)
        {

            var descriptionModel = descriptionDto.ToDescriptionFromUpdateDto(clothId);
            var existingDescription = _context.Description.FirstOrDefault(d => d.ClothId == clothId);

            if (existingDescription == null)
            {
                var result = await CreateAsync(descriptionModel);

                return result.Match<Result<DescriptionDto>>(
                    d => d.ToDescriptionDto(), error => error);
            }

            existingDescription.About = descriptionModel.About;
            existingDescription.Tecnical = descriptionModel.Tecnical;
            await _context.SaveChangesAsync();

            return existingDescription.ToDescriptionDto();

        }
    }
}