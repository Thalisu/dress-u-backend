using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Description;
using dress_u_backend.models;

namespace dress_u_backend.Mappers
{
    public static class DescriptionMapper
    {
        public static DescriptionDto ToDescriptionDto(this Description description)
        {
            return new DescriptionDto
            {
                About = description.About,
                Tecnical = description.Tecnical
            };
        }
        public static Description ToDescriptionFromCreateDto(this CreateDescriptionRequestDto descriptionDto, int clothId)
        {
            return new Description
            {
                ClothId = clothId,
                About = descriptionDto.About,
                Tecnical = descriptionDto.Tecnical
            };
        }
    }
}