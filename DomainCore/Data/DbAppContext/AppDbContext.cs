using Microsoft.EntityFrameworkCore;
using DomainCore.Data.Identity;
using DomainCore.Data.Models;

namespace DomainCore.Data.DbAppContext
{
    public class AppDbContext : DbContext
    {
        #region Construct

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        #endregion

        #region DbSet's

        public DbSet<ProfileInfo> ProfileInfo { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sellers> Sellers { get; set; }

        #endregion
    }
}
