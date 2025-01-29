using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.interfaces;
using dress_u_backend.Interfaces;
using dress_u_backend.Repository;
using dress_u_backend.Services;

namespace dress_u_backend.Config.Programs
{
    public static class AddDependancyInjections
    {
        public static IServiceCollection AddDependancies(
            this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClothRepository, ClothRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryClothRepository, CategoryClothRepository>();
            services.AddScoped<IDescriptionRepository, DescriptionRepository>();
            return services;
        }

    }
}