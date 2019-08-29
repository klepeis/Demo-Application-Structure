using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Inventory.DataAccessObjects.Entitys;
using Product.Domain.Product.DataAccessObjects.Entitys;

namespace Product.Domain.Infrastructure.EntityTypeConfigurations
{
    internal class ProductDetailTypeConfiguration : IEntityTypeConfiguration<ProductDetailEntity>
    {
        public void Configure(EntityTypeBuilder<ProductDetailEntity> builder)
        {
            builder.ToTable("product");
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.InventoryDetail)
                   .WithOne(i => i.ProductDetail)
                   .HasForeignKey<InventoryDetailEntity>(i => i.ProductId);
        }
    }
}
