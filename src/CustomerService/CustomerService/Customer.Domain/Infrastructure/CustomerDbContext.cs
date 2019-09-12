using Customer.Domain.Infrastructure.EntityTypeConfigurations;
using Customer.Domain.CustomerModule.DataAccessObjects.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Domain.UnitTests")]
namespace Customer.Domain.Infrastructure
{
    internal class CustomerDbContext : DbContext
    {
        public DbSet<CustomerEntity> CustomerProfiles { get; set; }

        public CustomerDbContext() { }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerProfileTypeConfiguration());
        }
    }
}
