using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DomainCore.Data.DbAppContext;
using DomainCore.Data.Identity;

namespace DomainCore.Config
{
    public static class ConfigDBServices
    {
        #region DBConnect

        public static void AddDBInfo(
            this IServiceCollection services)
        {
            //  config context to DataBase
            //services.AddDbContext<AppDbContext>(
            //    option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // config context to MemoryDataBase (just for tests)
            services.AddDbContext<AppDbContext>(
                option => option.UseInMemoryDatabase("ShoppingAppTestDB"));
        }

        #endregion
    }
}
