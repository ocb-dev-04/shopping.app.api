using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DomainCore.Data.Entities.Identity;
using DomainCore.Data.Entities.App;

namespace DomainCore.Data.DataBaseContext
{
    public class AppDbContext : IdentityDbContext<AppIdentityUser>
    {
        #region Construct

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        #endregion

        #region DbSet's

        // admin entities
        public DbSet<Products> Products { get; set; }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<ProfileInfo> ProfileInfo { get; set; }

        #endregion
    }
}
