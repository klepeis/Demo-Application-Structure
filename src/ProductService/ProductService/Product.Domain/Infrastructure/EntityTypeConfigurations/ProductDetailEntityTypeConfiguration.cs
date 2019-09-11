using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities;
using Product.Domain.ProductComponent.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.Infrastructure.EntityTypeConfigurations
{
    /// <summary>
    /// Entity Type Configuration for ProductDetail
    /// </summary>
    internal class ProductDetailEntityTypeConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("product");
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.InventoryDetail)
                   .WithOne(i => i.ProductDetail)
                   .HasForeignKey<InventoryEntity>(i => i.ProductId);
        }
    }
}
