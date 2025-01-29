using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using Microsoft.EntityFrameworkCore;

namespace app.Config.Programs
{
    public static class AddDBContext
    {
        public static IServiceCollection AddDBContextService(
            this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}