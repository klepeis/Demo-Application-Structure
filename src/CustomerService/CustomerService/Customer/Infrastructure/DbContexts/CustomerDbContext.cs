using Customer.Profile.DataAccessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.DbContexts
{
    internal class CustomerDbContext : DbContext
    {
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region dbo.CustomerProfiles

            modelBuilder.Entity<CustomerProfile>()
                .HasKey(e => e.Id);

            #endregion
        }
    }
}
