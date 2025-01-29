using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dress_u_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace dress_u_backend.Config.Programs
{
    public static class AddDBContext
    {
        public static IServiceCollection AddDBContextService(
            this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}