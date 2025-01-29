using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Config
{
    public static class AppSettings
    {
        public static string GetJwtSigningKey(this IConfiguration config)
        {
            return config["Jwt:SigningKey"]
                ?? throw new InvalidOperationException(
                    "Define Jwt:SigningKey in appsettings.json");
        }
        public static string GetJwtIssuer(this IConfiguration config)
        {
            return config["Jwt:Issuer"]
                ?? throw new InvalidOperationException(
                    "Define Jwt:Issuer in appsettings.json");
        }
        public static string GetJwtAudience(this IConfiguration config)
        {
            return config["Jwt:Audience"]
                ?? throw new InvalidOperationException(
                    "Define Jwt:Audience in appsettings.json");
        }
        public static string GetConfig(this IConfiguration config, string key)
        {
            return config[key]
                ?? throw new ArgumentNullException(
                    key, key + " is null");
        }
    }
}