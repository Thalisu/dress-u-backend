using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Interfaces;
using app.Repository;
using app.Services;

namespace app.Config.Programs
{
    public static class AddDependancyInjections
    {
        public static IServiceCollection AddDependancies(
            this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();
            return services;
        }

    }
}