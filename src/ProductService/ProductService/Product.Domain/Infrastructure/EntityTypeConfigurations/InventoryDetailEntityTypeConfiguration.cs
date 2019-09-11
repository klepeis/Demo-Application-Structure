using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.Infrastructure.EntityTypeConfigurations
{
    /// <summary>
    /// Entity Type Configuration for InventoryDetail model.
    /// </summary>
    internal class InventoryDetailEntityTypeConfiguration : IEntityTypeConfiguration<InventoryEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            builder.ToTable("inventory");
            builder.HasKey(e => e.ProductId);

            // TODO: Research this.
            //builder.Metadata.FindNavigation(nameof(InventoryDetailEntity.ProductDetail));
        }
    }
}
