using Microsoft.EntityFrameworkCore;

namespace Order.Customer.Infrastructure.DbContexts
{
    internal class CustomerDbContext : DbContext
    {
        public CustomerDbContext() {}

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
