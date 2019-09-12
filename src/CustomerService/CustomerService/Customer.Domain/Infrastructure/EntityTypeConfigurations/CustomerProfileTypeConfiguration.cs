using Customer.Domain.CustomerModule.DataAccessObjects.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Domain.Infrastructure.EntityTypeConfigurations
{
    internal class CustomerProfileTypeConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("customer");
            builder.HasKey(e => e.Id);
        }
    }
}
