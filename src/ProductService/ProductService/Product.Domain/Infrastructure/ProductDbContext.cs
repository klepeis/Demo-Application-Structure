using Microsoft.EntityFrameworkCore;
using Product.Domain.Infrastructure.EntityTypeConfigurations;
using Product.Domain.Inventory.DataAccessObjects.DataModels.Entitys;
using Product.Domain.Product.DataAccessObjects.DataModels.Entitys;

namespace Product.Domain.Infrastructure
{
    internal class ProductDbContext : DbContext
    {
        public DbSet<InventoryDetailEntity> InventoryDetails { get; set; }
        public DbSet<ProductDetailEntity> Products { get; set; }

        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryDetailTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailTypeConfiguration());
        }
    }
}
