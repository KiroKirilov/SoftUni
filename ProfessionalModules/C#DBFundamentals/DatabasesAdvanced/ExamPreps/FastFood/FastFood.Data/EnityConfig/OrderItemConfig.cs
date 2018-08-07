using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data.EnityConfig
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => new { e.ItemId, e.OrderId });

            builder.HasOne(e => e.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(e => e.OrderId);

            builder.HasOne(e => e.Item)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(e => e.ItemId);
        }
    }
}
