using Customer.Profile.DataAccessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
namespace Customer.Infrastructure.DbContexts
{
    internal class CustomerDbContext : DbContext
    {
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }

        public CustomerDbContext() { }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region dbo.CustomerProfiles

            modelBuilder.Entity<CustomerProfile>()
                .HasKey(e => e.Id);

            #endregion
        }
    }
}
