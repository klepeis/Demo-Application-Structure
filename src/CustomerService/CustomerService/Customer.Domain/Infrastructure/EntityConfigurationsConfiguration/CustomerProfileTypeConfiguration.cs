using Customer.Domain.Profile.DataAccessObjects.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Domain.Infrastructure.EntityConfigurationsConfiguration
{
    internal class CustomerProfileTypeConfiguration : IEntityTypeConfiguration<CustomerProfileEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerProfileEntity> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(e => e.Id);
        }
    }
}
