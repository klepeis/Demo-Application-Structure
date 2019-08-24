using Customer.Domain.Profile.DataAccessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Domain.Infrastructure.EntityConfigurationsConfiguration
{
    internal class CustomerProfileTypeConfiguration : IEntityTypeConfiguration<CustomerProfile>
    {
        public void Configure(EntityTypeBuilder<CustomerProfile> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(e => e.Id);
        }
    }
}
