using DomainCore.Data.DbAppContext;
using DomainCore.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Config
{
    public static class ConfigDBServices
    {
        #region DBConnect

        public static void AddDBInfo(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            //  config context to DataBase
            //services.AddDbContext<AppDbContext>(
            //    option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // config context to MemoryDataBase (just for tests)
            services.AddDbContext<AppDbContext>(
                option => option.UseInMemoryDatabase("ShoppingAppTestDB"));

            //  identity config (to create users)
            services.AddIdentity<UserAppIdentity, IdentityRole>(
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
                ).AddDefaultTokenProviders();
        }

        #endregion
    }
}
