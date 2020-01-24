using System;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DomainCore.Data.DataBaseContext;
using DomainCore.Data.Entities.Identity;
using DomainCore.Core.Interfaces.Identity;
using DomainCore.Core.Reps.Identity;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiCore.ConfigServices
{
    public static class AddAllServices
    {
        #region AddDI

        //  add all dependecies inyeccion
        public static void AddDI(this IServiceCollection services)
        {
            #region Identity DI

            services.AddScoped<IIdentityUserRep, IdentityUserRep>();

            #endregion
        }

        #endregion

        #region DBConnect

        public static void AddDBInfo(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            //  config context to DataBase
            services.AddDbContext<AppDbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //  identity config (to create users)
            services.AddIdentity<AppIdentityUser, IdentityRole>(
                    option =>
                    {
                        //  for email confirmation
                        option.User.RequireUniqueEmail = true;

                        //  password config
                        option.Password.RequireDigit = true;
                        option.Password.RequiredLength = 6;
                        option.Password.RequireNonAlphanumeric = false;
                        option.Password.RequireUppercase = false;
                        option.Password.RequireLowercase = true;
                    }
                ).AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        #endregion

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

        #region AddSwagger

        public static void AddSwagger(this IServiceCollection services)
        //=> services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo
        //        {
        //            Title = "Employee API",
        //            Version = "v1",
        //            Description = "An API to perform Employee operations",
        //            TermsOfService = new Uri("https://example.com/terms"),
        //            Contact = new OpenApiContact
        //            {
        //                Name = "John Walkner",
        //                Email = "John.Walkner@gmail.com",
        //                Url = new Uri("https://twitter.com/jwalkner"),
        //            },
        //            License = new OpenApiLicense
        //            {
        //                Name = "Employee API LICX",
        //                Url = new Uri("https://example.com/license"),
        //            }
        //        });
        //    });
        => services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new Info { Title = "Shop App - API", Version = "v1", Description = "Breve descripcion de la API en si" })
            );

        #endregion
    }
}
