using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace app.Config.Programs
{
    public static class Auth
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, WebApplicationBuilder builder)
        {

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDBContext>();

            var jwtKey = builder.Configuration.GetJwtSigningKey();
            var issuer = builder.Configuration.GetJwtIssuer();
            var audience = builder.Configuration.GetJwtAudience();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme
                = options.DefaultChallengeScheme
                = options.DefaultForbidScheme
                = options.DefaultScheme
                = options.DefaultSignInScheme
                = options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(jwtKey)),
                    ValidateLifetime = true
                };
            });
            return services;
        }
    }
}