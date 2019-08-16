using Microsoft.EntityFrameworkCore;
using Order.OrderDetails.DataAccessObjects.Models;
using Order.OrderDetails.SharedModels;
using System;

namespace Order.Infrastructure.DbContexts
{
    internal class OrderDbContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region OrderDetails

            modelBuilder.Entity<OrderDetail>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderStatus)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));

            #endregion
        }
    }
}
