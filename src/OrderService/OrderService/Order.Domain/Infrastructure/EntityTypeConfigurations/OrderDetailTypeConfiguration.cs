using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.OrderDetails.DataAccessObjects.DataModels.Entitys;
using Order.Domain.OrderDetails.SharedModels;
using System;

namespace Order.Domain.Infrastructure.EntityTypeConfigurations
{
    internal class OrderDetailTypeConfiguration : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.ToTable("orderdetails");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.OrderStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));
        }
    }
}
