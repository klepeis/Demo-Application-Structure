﻿using Customer.Domain.Infrastructure.EntityTypeConfigurations;
using Customer.Domain.Profile.DataAccessObjects.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Domain.UnitTests")]
namespace Customer.Domain.Infrastructure
{
    internal class CustomerDbContext : DbContext
    {
        public DbSet<CustomerProfileEntity> CustomerProfiles { get; set; }

        public CustomerDbContext() { }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerProfileTypeConfiguration());
        }
    }
}