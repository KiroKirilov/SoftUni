using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data.EnityConfig
{
    using FastFood.Models;
    using FastFood.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Type)
                .HasDefaultValue(OrderType.ForHere)
                .IsRequired();

            builder.HasOne(e => e.Employee)
                .WithMany(x => x.Orders)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}
