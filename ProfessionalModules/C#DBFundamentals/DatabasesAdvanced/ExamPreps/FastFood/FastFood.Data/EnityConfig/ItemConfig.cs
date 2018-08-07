using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data.EnityConfig
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasAlternateKey(e => e.Name);

            builder.HasOne(e => e.Category)
                .WithMany(x => x.Items)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
