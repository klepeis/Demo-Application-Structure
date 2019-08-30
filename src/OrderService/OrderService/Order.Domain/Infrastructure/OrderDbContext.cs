using Microsoft.EntityFrameworkCore;
using Order.Domain.Infrastructure.EntityTypeConfigurations;
using Order.Domain.OrderDetails.DataAccessObjects.DataModels.Entitys;

namespace Order.Domain.Infrastructure
{
    internal class OrderDbContext : DbContext
    {
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailTypeConfiguration());
        }
    }
}
