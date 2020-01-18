using System;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DomainCore.Config
{
    public static class ConfigJWTServices
    {
        #region AddJWTAuth

        public static void AddJwtAuth(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            //  jwt auth config
            services.
                AddAuthentication(option => {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        //  uncomment this if you wanna use just a website
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetValue<string>("Jwt:Site"),

                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        #endregion
    }
}
