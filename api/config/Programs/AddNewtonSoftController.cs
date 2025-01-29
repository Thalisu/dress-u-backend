using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Config.Programs
{
    public static class AddNewtonSoftController
    {
        public static IServiceCollection AddNewtonsoftJsonController(
            this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            return services;
        }
    }
}