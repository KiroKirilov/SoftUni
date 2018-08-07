using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Data.EnityConfig
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasAlternateKey(e => e.Name);
        }
    }
}
