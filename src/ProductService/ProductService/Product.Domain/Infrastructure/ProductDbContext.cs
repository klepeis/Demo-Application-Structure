using Microsoft.EntityFrameworkCore;
using Product.Domain.Infrastructure.EntityTypeConfigurations;
using Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities;
using Product.Domain.ProductComponent.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.Infrastructure
{
    /// <summary>
    /// DbContext that encapsulates all product related entities. 
    /// </summary>
    internal class ProductDbContext : DbContext
    {
        #region Tables

        public DbSet<InventoryEntity> InventoryDetails { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        #endregion

        /// <summary>
        /// Create a new instance of the ProductDbContext.
        /// </summary>
        public ProductDbContext() { }

        /// <summary>
        /// Create a new instance of the ProductDbContext using the provided options.
        /// </summary>
        /// <param name="options"></param>
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Entity Type Configurations
            modelBuilder.ApplyConfiguration(new InventoryDetailEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailEntityTypeConfiguration());
        }
    }
}
