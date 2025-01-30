using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Dtos.Description;
using dress_u_backend.Models;
using Microsoft.OpenApi.Any;

namespace dress_u_backend.Interfaces
{
    public interface IDescriptionRepository
    {
        Task<Description> CreateAsync(Description description);
        Task<DescriptionDto?> UpdateAsync(int clothId, UpdateDescriptionRequestDto descriptionDto);
    }
}