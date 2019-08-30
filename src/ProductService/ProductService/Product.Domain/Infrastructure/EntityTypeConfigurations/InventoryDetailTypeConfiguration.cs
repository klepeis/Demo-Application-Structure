using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Inventory.DataAccessObjects.DataModels.Entitys;

namespace Product.Domain.Infrastructure.EntityTypeConfigurations
{
    internal class InventoryDetailTypeConfiguration : IEntityTypeConfiguration<InventoryDetailEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryDetailEntity> builder)
        {
            builder.ToTable("inventory");
            builder.HasKey(e => e.ProductId);

            // TODO: Research this.
            //builder.Metadata.FindNavigation(nameof(InventoryDetailEntity.ProductDetail));
        }
    }
}
