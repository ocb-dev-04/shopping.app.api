using System;
using System.Text;
using System.Reflection;
using System.IO;

using Microsoft.OpenApi.Models;
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
using DomainCore.Core.Reps.App;
using DomainCore.Core.Interfaces.App;

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
            services.AddScoped<IProfileInfosRep, ProfileRep>();

            #endregion

            #region App DI

            services.AddScoped<ICartRep, CartRep>();
            services.AddScoped<IProductsRep, ProductsRep>();
            services.AddScoped<ISellersRep, SellersRep>();

            #endregion
        }

        #endregion

        #region DBConnect

        public static void AddDBInfo(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            //  config context to DataBase
            //services.AddDbContext<AppDbContext>(
            //    option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // config context to test database
            services.AddDbContext<AppDbContext>(
                option => option.UseInMemoryDatabase("ShopAPI_DB"));

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

        public static void AddLocalSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Shop API",
                        Version = "v1",
                        Description = "API para manejo de una tienda en linea",
                        Contact = new OpenApiContact
                        {
                            Name = "Oscar Chavez",
                            Email = "oscarchb04@gmail.com",
                            Url = new Uri("https://github.com/ocb-dev-04"),
                        }
                    });

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });

        #endregion
    }
}
