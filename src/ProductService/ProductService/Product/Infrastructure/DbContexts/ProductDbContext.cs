using Microsoft.EntityFrameworkCore;
using Product.Inventory.DataAccessObjects.Models;
using ProductDetailModels = Product.ProductDetail.DataAccessObjects.Models;

namespace Product.Infrastructure.DbContexts
{
    internal class ProductDbContext : DbContext
    {
        public DbSet<InventoryDetail> InventoryDetails { get; set; }
        public DbSet<ProductDetailModels.ProductDetail> Products { get; set; }

        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Inventory

            modelBuilder.Entity<InventoryDetail>()
                .ToTable("Inventory");

            modelBuilder.Entity<InventoryDetail>()
                .HasKey(e => e.ProductId);

            #endregion

            #region Products

            modelBuilder.Entity<ProductDetailModels.ProductDetail>()
                .ToTable("Products");

            modelBuilder.Entity<ProductDetailModels.ProductDetail>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ProductDetailModels.ProductDetail>()
                .HasOne(p => p.InventoryDetail)
                .WithOne(i => i.ProductDetail)
                .HasForeignKey<InventoryDetail>(i => i.ProductId);

            #endregion
        }
    }
}
